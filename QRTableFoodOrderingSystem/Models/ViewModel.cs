namespace QRTableFoodOrderingSystem.Models
{
    public class FoodItemVM
    {
        public int FoodItemId { get; set; }
        public int countFoodItem { get; set; }
    }
   
    public class DashboardVM     //To do dashboard for all of the model
    {
        public List<Payment>payments {  get; set; } 
        public List<FoodItemVM> foodItems { get; set; }
    }
}
