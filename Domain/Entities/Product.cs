namespace Domain.Entities
{
    using Abstractions;

    public class Product : Entity<int>
    {
        public Product(string? name, string? productNumber, bool? makeFlag, bool? finishedGoodsFlag, string? color, short? safetyStockLevel, short? reorderPoint, decimal? standardCost, decimal? listPrice, string? size, string? sizeUnitMeasureCode, string? weightUnitMeasureCode, decimal? weight, int? daysToManufacture, string? productLine, string? @class, string? style, int? productSubcategoryId, int? productModelId, DateTime sellStartDate, DateTime? sellEndDate, DateTime? discontinuedDate)
        {
            Name = name;
            ProductNumber = productNumber;
            MakeFlag = makeFlag;
            FinishedGoodsFlag = finishedGoodsFlag;
            Color = color;
            SafetyStockLevel = safetyStockLevel;
            ReorderPoint = reorderPoint;
            StandardCost = standardCost;
            ListPrice = listPrice;
            Size = size;
            SizeUnitMeasureCode = sizeUnitMeasureCode;
            WeightUnitMeasureCode = weightUnitMeasureCode;
            Weight = weight;
            DaysToManufacture = daysToManufacture;
            ProductLine = productLine;
            Class = @class;
            Style = style;
            ProductSubcategoryID = productSubcategoryId;
            ProductModelID = productModelId;
            SellStartDate = sellStartDate;
            SellEndDate = sellEndDate;
            DiscontinuedDate = discontinuedDate;
        }

        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public bool? MakeFlag { get; set; }
        public bool? FinishedGoodsFlag { get; set; }
        public string? Color { get; set; }
        public short? SafetyStockLevel { get; set; }
        public short? ReorderPoint { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? ListPrice { get; set; }
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; }
        public string? WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int? DaysToManufacture { get; set; }
        public string? ProductLine { get; set; }
        public string? Class { get; set; }
        public string? Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
    }
}