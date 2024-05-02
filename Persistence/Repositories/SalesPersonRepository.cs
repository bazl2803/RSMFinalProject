namespace Persistence.Repositories
{
    using Domain.Entities;

    public sealed class SalesPersonRepository(ApplicationDbContext dbContext)
        : Repository<SalesPerson>(dbContext);
}