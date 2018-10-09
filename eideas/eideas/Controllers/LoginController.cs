using eideas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eideas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration config)
        {
            this.configuration = config;
        }


        public IActionResult Login()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnectionString");

            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("Select count(*) from dbo.[BTUser]", con);
            con.Open();
            var count = (int)command.ExecuteScalar();

            con.Close();
            return View("~/Views/Auth/Login.cshtml", new LoginModel());
        }
    }
}
