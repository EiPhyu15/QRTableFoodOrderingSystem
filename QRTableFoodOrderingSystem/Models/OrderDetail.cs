using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRTableFoodOrderingSystem.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId {  get; set; }
        public int Quantity {  get; set; }
        public double Price {  get; set; }
        public int FoodItemI {  get; set; }
        [ForeignKey("FoodItemI")]
        public FoodItem FoodItem { get; set; }
        public int OrderId {  get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
