namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public class SalesSummaryOrderDateSpecification : ISalesSpecification
    {
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;

        public SalesSummaryOrderDateSpecification(DateTime fromDate, DateTime toDate)
        {
            _fromDate = fromDate;
            _toDate = toDate;
        }

        public Expression<Func<SalesOrderDetail, bool>> GetExpression()
        {
            return sod => sod.SalesOrderHeader.OrderDate >= _fromDate &&
                          sod.SalesOrderHeader.OrderDate <= _toDate;
        }
    }
}