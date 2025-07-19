using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRTableFoodOrderingSystem.Models
{
    public class QRCode
    {
        [Key]
        public int QRId {  get; set; }
        public int TableNumber {  get; set; }
        public string Code {  get; set; }
        public DateTime QRGenerateDate { get; set; }
        [ForeignKey("TableNumber")]
        public Table Table { get; set; }
        public ICollection<Order> Order { get; set; }



        
    }
}
