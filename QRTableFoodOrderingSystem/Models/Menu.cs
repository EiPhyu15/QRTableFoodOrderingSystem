namespace QRTableFoodOrderingSystem.Models
{
    public class Menu
    {
        public int MenuId {  get; set; }
        public string MenuTitle {  get; set; }
        public bool MenuStatus {  get; set; }
        public ICollection<FoodItem> FoodItems { get; set; }
    }
}
