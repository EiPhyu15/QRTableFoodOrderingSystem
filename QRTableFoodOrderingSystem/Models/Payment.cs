using System.ComponentModel.DataAnnotations.Schema;

namespace QRTableFoodOrderingSystem.Models
{
    public class Payment
    {
        public int PaymentId {  get; set; }
        public double Amount {  get; set; }
        public string PaymentMethod {  get; set; }
        public DateOnly PaymentDate { get; set; }
        public int OrderId {  get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
