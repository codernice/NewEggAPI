using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.NewEgg.Model
{
    public class StandardOrderEgg
    {
        public StandardOrderEgg()
        {
            this.Detail = new HashSet<StandardOrderDetail>();
        }

        public string OrderID { get; set; }
        public string PlatformOrderID { get; set; }
        public int PlatformType { get; set; }
        public int ShopInfoID { get; set; }
        public string TransactionID { get; set; }
        public string UserID { get; set; }
        public int Status { get; set; }
        public System.DateTime SaleDate { get; set; }
        public Nullable<System.DateTime> PaidOnDate { get; set; }
        public Nullable<System.DateTime> ShippedOnDate { get; set; }
        public Nullable<System.DateTime> DeliveredTime { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string TrackingName { get; set; }
        public string TrackingNumber { get; set; }
        public string ReceiveName { get; set; }
        public string ReceivePhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        public decimal? Price { get; set; }
        public decimal? Shipping { get; set; }
        public decimal? PriceCost { get; set; }
        public decimal? ShippingCost { get; set; }
        public decimal? OrderTotal { get; set; }
        public string Currency { get; set; }
        public bool? IsWishExpress { get; set; }
        public string SalesChannel { get; set; }
        public int OrderType { get; set; }
        public System.DateTime? PlatformLastUpTime { get; set; }
        public System.DateTime LastModifyTime { get; set; }
        public System.DateTime CreateTime { get; set; }

        public virtual ICollection<StandardOrderDetail> Detail { get; set; }
    }

    public partial class StandardOrderDetail
    {
        public string DetailId { get; set; }
        public string OrderID { get; set; }
        public string ProductName { get; set; }
        public string SellerSku { get; set; }
        public int Quantity { get; set; }
        public string Currency { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? Amount { get; set; }
    }
}
