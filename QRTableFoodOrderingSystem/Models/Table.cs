using System.ComponentModel.DataAnnotations;

namespace QRTableFoodOrderingSystem.Models
{
    public class Table
    {
        [Key]
        public int TableNumber {  get; set; }
        public int SeatCount {  get; set; }
        public bool IsAvaliable {  get; set; }


    }
}
