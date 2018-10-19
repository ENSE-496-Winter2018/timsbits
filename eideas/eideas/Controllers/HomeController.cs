using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eideas.Models;
using eideas.Data;
using eideas.Areas.Identity.Data;

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
            
                

            return View(new IdeaModel
            {
                Ideas = ideas,
                NewIdea = new Idea()
            });
        }

        [HttpPost]
        public IActionResult Ideas(Idea newIdea) {

            db.Ideas.Add(newIdea);
            db.SaveChanges();

            ICollection<Idea> ideas = db.Ideas.ToList();

            return View(new IdeaModel
            {
                Ideas = ideas,
                NewIdea = new Idea()
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
