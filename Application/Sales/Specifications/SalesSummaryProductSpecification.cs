namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public class SalesSummaryProductSpecification : ISalesSpecification
    {
        public Expression<Func<SalesOrderDetail, bool>> GetExpression()
        {
            throw new NotImplementedException();
        }
    }
}