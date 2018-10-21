using eideas.Areas.Identity.Data;
using eideas.Data;
using eideas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eideas.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext db;

        public RegistrationController(ApplicationDbContext context)
        {

            db = context;
        }


        public IActionResult Register()
        {
            List<SelectListItem> lstdivisions = new List<SelectListItem>();

            if (db.Divisions != null)
            {
                foreach(var division in db.Divisions)
                {
                    SelectListItem i = new SelectListItem();
                    i.Value = division.DivisionId.ToString();
                    i.Text = division.DivisionName;
                    lstdivisions.Add(i);
                }
            }         

            return View("~/Views/Auth/Registration.cshtml", new RegistrationModel() { LstDivision = lstdivisions });
        }
    }
}
