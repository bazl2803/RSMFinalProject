namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public class SalesSummaryCategorySpecification : ISalesSpecification
    {
        private readonly int? _categoryId;

        public SalesSummaryCategorySpecification(int? categoryId)
        {
            _categoryId = categoryId;
        }

        public Expression<Func<SalesOrderDetail, bool>> GetExpression()
        {
            return e => e.Product.ProductSubcategory.ProductCategory.Id == _categoryId;
        }
    }
}