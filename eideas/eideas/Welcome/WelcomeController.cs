﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace eideas.NewFolder
{
    public class WelcomeController : Controller
    {
        readonly ApplicationDbContext db;
        readonly UserManager<EIdeasUser> userManager;

        public WelcomeController(ApplicationDbContext context, UserManager<EIdeasUser> _userManager)
        {
            db = context;
            userManager = _userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            ICollection<Idea> ideas = db.Ideas.Include(i => i.IdeaUpdoots)./*OrderByDescending(i => i.IdeaUpdoots).*/Take(5).ToList();

            return View("~/Welcome/Welcome.cshtml", ideas);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Upvote([FromBody] int ideaId) {
            var uid = userManager.GetUserId(HttpContext.User);
            EIdeasUser user = await userManager.FindByIdAsync(uid);

            Idea idea = db.Ideas.First(i => i.IdeaId == ideaId);

            IdeaUpDoot ideaUpDoot = new IdeaUpDoot
            {
                IdeaId = ideaId,
                EideasUser = user
            };

            idea.IdeaUpdoots.Add(ideaUpDoot);
            db.SaveChanges();

            return StatusCode(200);
        }
    }
}
