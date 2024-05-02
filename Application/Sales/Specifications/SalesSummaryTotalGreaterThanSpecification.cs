namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public class SalesSummaryTotalGreaterThanSpecification : ISalesSpecification
    {
        private readonly decimal? _total;

        public SalesSummaryTotalGreaterThanSpecification(decimal? total)
        {
            _total = total;
        }

        public Expression<Func<SalesOrderDetail, bool>> GetExpression()
        {
            return e => e.LineTotal >= _total;
        }
    }
}