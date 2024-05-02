namespace Application.Sales.Specifications
{
    using System.Linq.Expressions;
    using Domain.Entities;

    public class SalesSummaryProductSpecification : ISalesSpecification
    {
        private readonly int? _productId;

        public SalesSummaryProductSpecification(int? productId)
        {
            _productId = productId;
        }

        public Expression<Func<SalesOrderDetail, bool>> GetExpression()
        {
            return sd => sd.Product.Id == _productId;
        }
    }
}