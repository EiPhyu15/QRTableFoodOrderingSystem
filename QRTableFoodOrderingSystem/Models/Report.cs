using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace QRTableFoodOrderingSystem.Models
{
    public class Report
    {
        public int ReportId {  get; set; }
        public string ReportName { get; set; }
        public DateTime ReportDate { get; set; }
        public int StaffId {  get; set; }
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }
    }
}
