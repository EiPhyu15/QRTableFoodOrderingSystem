using System.ComponentModel.DataAnnotations;

namespace QRTableFoodOrderingSystem.Models
{
    public class Staff
    {
        [Key]
        public int StaffId {  get; set; }
        public string FName {  get; set; }
        public string LName {  get; set; }
        public string Email {  get; set; }
        public string Address {  get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Report> Reports { get; set; }

    }
}
