namespace Application.Queries
{
    using Domain.Entities;

    public class ByDateRangeCriteria : ISalesCriteria
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public ByDateRangeCriteria(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public IQueryable<SalesOrderDetail> Apply(IQueryable<SalesOrderDetail> query)
        {
            return query.Where(sd =>
                sd.SalesOrderHeader!.OrderDate >= _startDate && sd.SalesOrderHeader.OrderDate <= _endDate);
        }
    }
}