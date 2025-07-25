using Microsoft.AspNetCore.Mvc;
using QRTableFoodOrderingSystem.Models;
using QRTableFoodOrderingSystem.Services;

namespace QRTableFoodOrderingSystem.Controllers
{
    //Object instantiation of the EmailService class from Services folder
    public class EmailController : Controller
    {
        //Object instantiation of the EmailService class from Services folder
        private readonly EmailService _emailService;

        //Constructor to initialize the _emailService object
        //If no initialization it will yield an error when running
        //The error object instance is set to null
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmailAsync(model);
                ViewBag.Message = "Email sent successfully!";
            }

            return View();
        }
    }
}
