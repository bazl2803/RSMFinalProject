namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public class SalesSummarySalesPersonSpecification : ISalesSpecification
    {
        private readonly int? _salesPersonId;

        public SalesSummarySalesPersonSpecification(int? salesPersonId)
        {
            _salesPersonId = salesPersonId;
        }

        public Expression<Func<SalesOrderDetail, bool>> GetExpression()
        {
            return e => e.SalesOrderHeader.SalesPerson.Id == _salesPersonId;
        }
    }
}