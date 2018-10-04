using eideas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eideas.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Register()
        {
            return View("~/Views/Auth/Register.cshtml", new LoginModel());
        }
    }
}
