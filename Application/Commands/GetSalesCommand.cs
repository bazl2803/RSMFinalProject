namespace Application.Commands
{
    using Data;
    using Sales;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public sealed class GetSalesCommand
    {
        private readonly IApplicationDbContext _context;

        public GetSalesCommand(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesResponse>> Handle(GetSalesQuery request, int PageSize)
        {
            int? cursor = null;

            var response =
                await (from sod in _context.SalesOrderDetails
                        join soh in _context.SalesOrderHeaders on sod.SalesOrderID equals soh.Id
                        join sp in _context.SalesPersons on soh.SalesPersonID equals sp.Id
                        join p in _context.Products on sod.ProductID equals p.Id
                        join sub in _context.ProductSubcategories on p.ProductSubcategoryID equals sub.Id
                        join ship in _context.Addresses on soh.ShipToAddressID equals ship.Id
                        join bill in _context.Addresses on soh.ShipToAddressID equals bill.Id
                        where cursor == null || sod.Id > cursor
                        orderby sod.Id
                        select new SalesResponse
                        {
                            TotalSale = sod.LineTotal,
                            OrderDate = soh.OrderDate,
                            ProductName = p.Name,
                            ProductCategory = sub.Name,
                            SalesPersonName = $"{sp.FirstName} {sp.MiddleName} {sp.LastName}",
                            ShippingAddress = ship.AddressLine1,
                            BillingAddress = bill.AddressLine1
                        })
                    .Take(PageSize)
                    .ToListAsync();

            return response;
        }
    }
}