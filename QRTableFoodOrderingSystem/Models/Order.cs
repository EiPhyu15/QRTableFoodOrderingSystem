using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace QRTableFoodOrderingSystem.Models
{
    public class Order
    {
        public int OrderId {  get; set; }
        public string OrderStatus {  get; set; }
        public string PaymentStatus {  get; set; }
        public double TotalAmount {  get; set; }
        public DateOnly OrderDate { get; set; }
        public bool isSenttoKitchen {  get; set; }
        public bool isPrepared {  get; set; }
        public bool isSenttoTable {  get; set; }
        public int QRId { get; set; }
        [ForeignKey("QRId ")]
        public QRCode QRCode { get; set; }
        public int StaffId {  get; set; }
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
       



    }
}
