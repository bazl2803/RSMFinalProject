namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public interface ISalesSpecification
    {
        Expression<Func<SalesOrderDetail, bool>> GetExpression();
    }
}