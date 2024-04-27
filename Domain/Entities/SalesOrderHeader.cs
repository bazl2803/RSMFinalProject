namespace Domain.Entities
{
    using Abstractions;

    public class SalesOrderHeader : Entity<int>
    {
        public SalesOrderHeader(
            int id,
            byte? revisionNumber,
            DateTime? orderDate,
            DateTime? dueDate,
            DateTime? shipDate,
            byte? status,
            bool? onlineOrderFlag,
            string? salesOrderNumber,
            string? purchaseOrderNumber,
            string? accountNumber,
            int? customerId,
            int? salesPersonId,
            int? territoryId,
            int? billToAddressId,
            int? shipToAddressId,
            int? shipMethodId,
            int? creditCardId,
            string? creditCardApprovalCode,
            int? currencyRateId,
            decimal? subtotal,
            decimal? taxAmt,
            decimal? freight,
            decimal? totalDue,
            string? comment) : base(id)
        {
            RevisionNumber = revisionNumber;
            OrderDate = orderDate;
            DueDate = dueDate;
            ShipDate = shipDate;
            Status = status;
            OnlineOrderFlag = onlineOrderFlag;
            SalesOrderNumber = salesOrderNumber;
            PurchaseOrderNumber = purchaseOrderNumber;
            AccountNumber = accountNumber;
            CustomerId = customerId;
            SalesPersonID = salesPersonId;
            TerritoryID = territoryId;
            BillToAddressID = billToAddressId;
            ShipToAddressID = shipToAddressId;
            ShipMethodID = shipMethodId;
            CreditCardID = creditCardId;
            CreditCardApprovalCode = creditCardApprovalCode;
            CurrencyRateID = currencyRateId;
            Subtotal = subtotal;
            TaxAmt = taxAmt;
            Freight = freight;
            TotalDue = totalDue;
            Comment = comment;
        }

        private SalesOrderHeader()
        {
        }

        public byte? RevisionNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte? Status { get; set; }
        public bool? OnlineOrderFlag { get; set; }
        public string? SalesOrderNumber { get; }
        public string? PurchaseOrderNumber { get; set; }
        public string? AccountNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonID { get; set; }
        public int? TerritoryID { get; set; }
        public int? BillToAddressID { get; set; }
        public int? ShipToAddressID { get; set; }
        public int? ShipMethodID { get; set; }
        public int? CreditCardID { get; set; }
        public string? CreditCardApprovalCode { get; set; }
        public int? CurrencyRateID { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TaxAmt { get; set; }
        public decimal? Freight { get; set; }
        public decimal? TotalDue { get; }
        public string? Comment { get; set; }
    }
}