namespace Application.Queries
{
    using Domain.Entities;

    public interface ISalesCriteria
    {
        IQueryable<SalesOrderDetail> Apply(IQueryable<SalesOrderDetail> query);
    }
}