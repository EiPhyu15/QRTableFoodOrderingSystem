using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace QRTableFoodOrderingSystem.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptId {  get; set; }
        public double TotalAmount {  get; set; }
        public DateOnly ReceiptDate {  get; set; }
        public int OrderId {  get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
