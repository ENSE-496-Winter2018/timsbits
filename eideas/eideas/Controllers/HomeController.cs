using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eideas.Models;
using eideas.Data;
using eideas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace eideas.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context) {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            //EIdeasUser user = db.Users.SingleOrDefault(u => u.Email == "test@test.com");
            //user.Organization = "Testy";

            //db.Users.Update(user);
            
            //user = db.Users.SingleOrDefault(u => u.Email == "test@test.com");

            //Console.Write(user.Organization);
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Ideas()
        {
            ViewData["Message"] = "Your contact page.";

            ICollection<Idea> ideas = new List<Idea>();

            if (db.Ideas != null)
                ideas = db.Ideas.ToList();
            
            ICollection<EIdeasUser> users = new List<EIdeasUser>();

            if (db.Users != null)
                users = db.Users.ToList();   
            
            ICollection<Division> divisions = new List<Division>();

            if (db.Divisions != null)
                divisions = db.Divisions.ToList();  

            ICollection<Unit> units = new List<Unit>();

            if (db.Units != null)
                units = db.Units.ToList(); 

            return View(new IdeaModel
            {
                Ideas = ideas,
                Users = users,
                Divisions = divisions,
                Units = units,
                NewIdea = new Idea(),
                NewComment = new IdeaComment()
            });
        }
        [HttpPost]
        [Route("AddComment")]
        public ActionResult Commented(IdeaComment NewComment)
        {
            NewComment.CreatedDate = DateTime.Now;
            db.IdeaComments.Add(NewComment);
            db.SaveChanges();

             ICollection<Idea> ideas = new List<Idea>();

            if (db.Ideas != null)
                ideas = db.Ideas.ToList();
            
            ICollection<EIdeasUser> users = new List<EIdeasUser>();

            if (db.Users != null)
                users = db.Users.ToList();   
            
            ICollection<Division> divisions = new List<Division>();

            if (db.Divisions != null)
                divisions = db.Divisions.ToList();  

            ICollection<Unit> units = new List<Unit>();

            if (db.Units != null)
                units = db.Units.ToList(); 

            return View(new IdeaModel
            {
                Ideas = ideas,
                Users = users,
                Divisions = divisions,
                Units = units,
                NewIdea = new Idea(),
                NewComment = new IdeaComment()
            });
        }

        [HttpPost]
        public IActionResult Ideas(Idea newIdea) {

            newIdea.CreatedBy = User.Identity.Name;
            newIdea.CreatedDate = DateTime.Now;
            db.Ideas.Add(newIdea);
            db.SaveChanges();

            ICollection<Idea> ideas = new List<Idea>();

            if (db.Ideas != null)
                ideas = db.Ideas.ToList();
            
            ICollection<EIdeasUser> users = new List<EIdeasUser>();

            if (db.Users != null)
                users = db.Users.ToList();   
            
            ICollection<Division> divisions = new List<Division>();

            if (db.Divisions != null)
                divisions = db.Divisions.ToList();  

            ICollection<Unit> units = new List<Unit>();

            if (db.Units != null)
                units = db.Units.ToList(); 

            return View(new IdeaModel
            {
                Ideas = ideas,
                Users = users,
                Divisions = divisions,
                Units = units,
                NewIdea = new Idea(),
                NewComment = new IdeaComment()
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
