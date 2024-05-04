namespace Application.Sales.GetRegionalSalesSummary
{
    using Abstractions;
    using Abstractions.Messaging;
    using Dapper;
    using Domain.Abstractions;
    using MediatR;
    using Microsoft.Data.SqlClient;

    public class
        GetRegionalSalesSummaryQueryHandler
        : IQueryHandler<GetRegionalSalesSummaryQuery, List<RegionalSalesSummaryResponse>>
    {
        public async Task<Result<List<RegionalSalesSummaryResponse>>> Handle(GetRegionalSalesSummaryQuery request,
            CancellationToken cancellationToken)
        {
            const string sql =
                @"WITH ProductData AS (
              SELECT sod.SalesOrderDetailID,
                     p.Name AS ProductName,
                     pc.Name AS Category,
                     sod.LineTotal
              FROM Sales.SalesOrderDetail sod
              INNER JOIN Production.Product p ON sod.ProductID = p.ProductID
              INNER JOIN Production.ProductSubcategory psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
              INNER JOIN Production.ProductCategory pc ON psc.ProductCategoryID = pc.ProductCategoryID
            ),
            QuarterData AS (
              SELECT sod.SalesOrderDetailID,
                     CONCAT(YEAR(soh.OrderDate), '-Q', DATEPART(quarter, soh.OrderDate)) AS Quarter
              FROM Sales.SalesOrderDetail sod
              INNER JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
            ),
            RegionData AS (
              SELECT sod.SalesOrderDetailID,
                     soh.TerritoryID
              FROM Sales.SalesOrderDetail sod
              INNER JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
            ),
            SummaryData AS (
              SELECT p.ProductName,
                     p.Category AS ProductCategory,
                     SUM(p.LineTotal) AS TotalSales,
                     r.TerritoryID,
                     q.Quarter
              FROM ProductData p
              INNER JOIN QuarterData q ON p.SalesOrderDetailID = q.SalesOrderDetailID
              INNER JOIN RegionData r ON p.SalesOrderDetailID = r.SalesOrderDetailID
              GROUP BY p.ProductName, p.Category, p.ProductName, r.TerritoryID, q.Quarter, r.TerritoryID
            ),
            CalculatedData AS (
              SELECT ProductName,
                     TotalSales,
                     ProductCategory,
                     TerritoryID,
                     Quarter,
                     LAG(Quarter) OVER (PARTITION BY TerritoryID ORDER BY TerritoryID) AS LastQuarter,
                     CAST((TotalSales * 100.0) / SUM(TotalSales) OVER (PARTITION BY sd.TerritoryID) AS FLOAT) AS PercentageOfTotalSalesInRegion,
                     CAST((SUM(TotalSales) OVER (PARTITION BY sd.ProductCategory, sd.TerritoryID) * 100.0) / SUM(TotalSales) OVER (PARTITION BY sd.TerritoryID) AS FLOAT) AS PercentageOfTotalCategorySalesInRegion
              FROM SummaryData sd
            )
            SELECT ProductName, TotalSales, PercentageOfTotalSalesInRegion, PercentageOfTotalCategorySalesInRegion
            FROM CalculatedData
            WHERE Quarter = LastQuarter";

            await using var connection = new SqlConnection("Database");
            var result = connection.Query<RegionalSalesSummaryResponse>(sql).ToList();

            return result;
        }
    }
}