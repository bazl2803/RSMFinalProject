namespace Application.Sales
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public static class SalesCriteria
    {
        public static Expression<Func<Product, bool>> ProductNameContains(string name)
        {
            return product => product.Name.Contains((name));
        }
    }
}