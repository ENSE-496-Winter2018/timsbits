using System;
using System.Linq;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            Idea idea = db.Ideas.First(i => i.IdeaId == ideaId);

            return View("~/IdeaDetail/IdeaDetail.cshtml", idea);
        }
    }
}
