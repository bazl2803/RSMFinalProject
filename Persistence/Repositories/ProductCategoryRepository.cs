namespace Persistence.Repositories
{
    using Domain.Entities;

    public class ProductCategoryRepository(ApplicationDbContext dbContext)
        : Repository<ProductCategory>(dbContext);
}