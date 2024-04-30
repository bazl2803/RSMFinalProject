namespace Application.Commands
{
    using Data;
    using System.Linq;
    using EfCore.Linq.ExtensionMethod;
    using Microsoft.EntityFrameworkCore;
    using Queries;

    public sealed class GetSalesCommand
    {
        private readonly IApplicationDbContext _context;

        public GetSalesCommand(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesResponse>> Handle(GetSalesQuery request)
        {
            var response = await
                (from sd in _context.SalesOrderDetails
                    join sh in _context.SalesOrderHeaders on sd.SalesOrderID equals sh.Id
                    join sp in _context.SalesPersons on sh.SalesPersonID equals sp.Id
                    join p in _context.Products on sd.ProductID equals p.Id
                    join sub in _context.ProductSubcategories on p.ProductSubcategoryID equals sub.Id
                    join ship in _context.Addresses on sh.ShipToAddressID equals ship.Id
                    join bill in _context.Addresses on sh.ShipToAddressID equals bill.Id
                    where request.Cursor == null || sd.Id > request.Cursor
                    orderby sd.Id
                    select new SalesResponse
                    {
                        TotalSale = sd.LineTotal,
                        OrderDate = sh.OrderDate,
                        ProductName = p.Name,
                        ProductCategory = sub.Name,
                        SalesPersonName = $"{sp.FirstName} {sp.MiddleName} {sp.LastName}",
                        ShippingAddress = ship.AddressLine1,
                        BillingAddress = bill.AddressLine1
                    })
                .Take(request.PageSize)
                .ToListAsync();

            return response;
        }
    }
}