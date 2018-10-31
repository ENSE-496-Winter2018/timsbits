using System;
using System.Linq;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eideas.IdeaController
{
	public class IdeaController : Controller
    {
        readonly ApplicationDbContext db;
        readonly UserManager<EIdeasUser> userManager;

        public IdeaController(ApplicationDbContext context, UserManager<EIdeasUser> _userManager)
        {
            db = context;
            userManager = _userManager;
        }

        public IActionResult Index(int ideaId) {
            if (ideaId == -1) {
                return Redirect("/Ideas");
            }

            Idea idea = db.Ideas
                          .Include(i => i.IdeaUpdoots)
                          .First(i => i.IdeaId == ideaId);

            return View("~/Idea/Idea.cshtml", idea);
        }
    }
}
