using eideas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eideas.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml", new LoginModel());
        }
    }
}
