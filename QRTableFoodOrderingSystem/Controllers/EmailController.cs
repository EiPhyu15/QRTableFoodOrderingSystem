using Microsoft.AspNetCore.Mvc;
using QRTableFoodOrderingSystem.Models;
using QRTableFoodOrderingSystem.Services;

namespace QRTableFoodOrderingSystem.Controllers
{
    //Object instantiation of the EmailService class from Services folder
    public class EmailController : Controller
    {
        private readonly EmailService _emailServices;
        //Constructor to initialize the _emailServices object
        //If no initialization it will yield an error when running 
        //The error object instance is set to email
        public EmailController(EmailService emailServices)
        {
           
            _emailServices = emailServices;
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
                await _emailServices.SendEmailAsync(model);
                ViewBag.Message = "Email sent sucessfully";
            }
            return View();
        }
    }
}
