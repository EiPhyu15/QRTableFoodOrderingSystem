using System.ComponentModel.DataAnnotations;

namespace QRTableFoodOrderingSystem.Models
{
    public class Menu
    {
        [Key]
        public int MenuId {  get; set; }
        public string MenuTitle {  get; set; }
        public bool MenuStatus {  get; set; }
        public string ImageUrl { get; set; }
        public ICollection<FoodItem> FoodItems { get; set; }
    }
}
