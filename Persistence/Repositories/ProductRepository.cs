namespace Persistence.Repositories
{
    using Domain.Entities;

    public class ProductRepository(ApplicationDbContext dbContext)
        : Repository<Product>(dbContext);
}