using System;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Mvc;

namespace eideas.Views.NewIdea
{
    public class NewIdeaController : Controller
    {
        readonly ApplicationDbContext db;

        public NewIdeaController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View("~/NewIdea/NewIdea.cshtml");
        }

        [HttpPost]
        public IActionResult CreateNewIdea(Idea newIdea)
        {
            newIdea.CreatedBy = User.Identity.Name;
            newIdea.CreatedDate = DateTime.Now;
            db.Ideas.Add(newIdea);
            db.SaveChanges();

            return Redirect("/Ideas");
        }
    }
}