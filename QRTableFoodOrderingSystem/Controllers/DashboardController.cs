using Microsoft.AspNetCore.Mvc;
using QRTableFoodOrderingSystem.Models;

namespace QRTableFoodOrderingSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            //var report = GenerateMockMonthlyPayments();
            var dvm = new DashboardVM();
            dvm.foodItems = GenerateFoodItems();
            dvm.payments= GenerateMockMonthlyPayments();
            ViewBag.totalSales=dvm.payments.Sum(p=>p.Amount).ToString("C2");
            return View(dvm);
        }
        public List<Payment> GenerateMockMonthlyPayments()
        {
            var monthlyPayments = new List<Payment>();
            monthlyPayments.Add(new Payment
            {
                PaymentId = 1,
                PaymentMethod = "Cash",
                Amount = 1000,
                PaymentDate = DateOnly.Parse("2025-01-01"),
                OrderId = 1,
            });
            monthlyPayments.Add(new Payment
            {
                PaymentId = 2,
                PaymentMethod = "Credit",
                Amount = 1500,
                PaymentDate = DateOnly.Parse("2025-02-02"),
                OrderId = 2,
            });
            monthlyPayments.Add(new Payment
            {
                PaymentId = 3,
                PaymentMethod = "Cash",
                Amount = 1000,
                PaymentDate = DateOnly.Parse("2025-03-03"),
                OrderId = 3,
            });
            monthlyPayments.Add(new Payment
            {
                PaymentId = 4,
                PaymentMethod = "Cash",
                Amount = 2000,
                PaymentDate = DateOnly.Parse("2025-04-04"),
                OrderId = 4,
            });
            monthlyPayments.Add(new Payment
            {
                PaymentId = 5,
                PaymentMethod = "Credit",
                Amount = 1000,
                PaymentDate = DateOnly.Parse("2025-05-05"),
                OrderId = 5,
            });
            monthlyPayments.Add(new Payment
            {
                PaymentId = 6,
                PaymentMethod = "Cash",
                Amount = 2500,
                PaymentDate = DateOnly.Parse("2025-06-06"),
                OrderId = 6,
            });
            monthlyPayments.Add(new Payment
            {
                PaymentId = 7,
                PaymentMethod = "Credit",
                Amount = 3000,
                PaymentDate = DateOnly.Parse("2025-07-07"),
                OrderId = 7,
            });
            return monthlyPayments.OrderBy(mp=>mp.PaymentDate).ToList();
        }
        public IActionResult DisplayFoodItems()
        {
            var fooditemreport = GenerateFoodItems();
            return View(fooditemreport);
        }
        public List<FoodItemVM> GenerateFoodItems()
        {
           var lstOrderDetail= new List<OrderDetail>();
            lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 1,
                Quantity=1,
                Price=200,
                FoodItemId=1,
                OrderId=1,
            });
           lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 2,
                Quantity = 2,
                Price = 100,
                FoodItemId = 2,
                OrderId = 2,
            });
            lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 3,
                Quantity = 3,
                Price = 100,
                FoodItemId = 2,
                OrderId = 3,
            });
            lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 4,
                Quantity = 3,
                Price = 150,
                FoodItemId =3 ,
                OrderId = 4,
            });
            lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 1,
                Quantity = 3,
                Price = 150,
                FoodItemId = 3,
                OrderId = 5,
            });
            lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 1,
                Quantity = 1,
                Price = 150,
                FoodItemId = 3,
                OrderId = 6,
            });
            lstOrderDetail.Add(new OrderDetail
            {
                OrderDetailId = 1,
                Quantity = 2,
                Price = 150,
                FoodItemId = 3,
                OrderId = 1,
            });
            var counts = lstOrderDetail.GroupBy(pr => pr.FoodItemId).Select(g => new
            {
                FoodItemId = g.Key,
                Count = g.Count()

            });
            var lstFoodItemVM = new List<FoodItemVM>();
            foreach (var item in counts)
            {
                lstFoodItemVM.Add(new FoodItemVM
                {
                    FoodItemId = item.FoodItemId,
                    countFoodItem = item.Count
                });
            }
            return lstFoodItemVM.OrderByDescending(p=>p.countFoodItem).ToList();
            
        }
    }
}
