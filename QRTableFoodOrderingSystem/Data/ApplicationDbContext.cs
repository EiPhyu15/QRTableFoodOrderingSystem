using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QRTableFoodOrderingSystem.Models;

namespace QRTableFoodOrderingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QRTableFoodOrderingSystem.Models.FoodItem> FoodItem { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Order> Order { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Payment> Payment { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.QRCode> QRCode { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Receipt> Receipt { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Report> Report { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Staff> Staff { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Table> Table { get; set; } = default!;
        public DbSet<QRTableFoodOrderingSystem.Models.Menu> Menu { get; set; } = default!;
    }
}
