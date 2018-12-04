using System;
using eideas.Areas.Identity.Data;
using eideas.Data;
using eideas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Views.NewIdea
{
    public class NewIdeaController : Controller
    {
        readonly ApplicationDbContext db;

        public NewIdeaController(ApplicationDbContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            IdeaModel modelio = new IdeaModel();
            modelio.Users = db.Users.ToList();
            modelio.Units = db.Units.ToList();
            modelio.Divisions = db.Divisions.ToList();
            
            return View("~/NewIdea/NewIdea.cshtml", modelio);
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult CreateNewIdea(Idea newIdea)
        {
            newIdea.CreatedBy = User.Identity.Name;
            newIdea.CreatedDate = DateTime.Now;
            newIdea.PDCA = (PDCA)1;
            db.Ideas.Add(newIdea);
            db.SaveChanges();

            return Redirect("/Ideas");
        }
    }
}