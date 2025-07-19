using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace QRTableFoodOrderingSystem.Models
{
    public class FoodItem
    {
        [Key]
        public int FoodItemId {  get; set; }
        public string FoodName { get; set;}
        public string FoodDescription { get; set;}
        public double Price {  get; set; }
        public string Category {  get; set;}
        public int MenuId {  get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
