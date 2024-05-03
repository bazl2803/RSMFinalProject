namespace Persistence.Repositories
{
    using Domain.Entities;
    using Domain.Repositories;

    public sealed class SalesPersonRepository(ApplicationDbContext dbContext)
        : Repository<SalesPerson>(dbContext), ISalesPersonRepository;
}