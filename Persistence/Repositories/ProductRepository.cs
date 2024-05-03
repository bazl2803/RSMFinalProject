namespace Persistence.Repositories
{
    using Domain.Entities;
    using Domain.Repositories;

    public class ProductRepository(ApplicationDbContext dbContext)
        : Repository<Product>(dbContext), IProductRepository;
}