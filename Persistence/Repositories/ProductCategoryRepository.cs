namespace Persistence.Repositories
{
    using Domain.Entities;
    using Domain.Repositories;

    public class ProductCategoryRepository(ApplicationDbContext dbContext)
        : Repository<ProductCategory>(dbContext), IProductCategoryRepository;
}