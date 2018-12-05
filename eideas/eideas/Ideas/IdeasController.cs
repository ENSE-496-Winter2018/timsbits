using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using eideas.Models;

namespace eideas.NewFolder
{
    public class IdeasController : Controller
    {
        readonly ApplicationDbContext db;
        readonly UserManager<EIdeasUser> userManager;
 
        public IdeasController(ApplicationDbContext context, UserManager<EIdeasUser> _userManager)
        {
            db = context;
            userManager = _userManager;
        }

        [Authorize]
        public IActionResult Index(string filter)
        {
            IdeaModel modelio = new IdeaModel();
            modelio.Users = db.Users.ToList();
            modelio.Units = db.Units.ToList();
            modelio.Divisions = db.Divisions.ToList();
            modelio.Ideas = db.Ideas.Include(i => i.IdeaUpdoots).Include(i=> i.EIdeasUser).ToList();

            if (filter != "Null")
            {
                switch (filter)
                {
                    case "TopIdeas":
                        modelio.Ideas = modelio.Ideas.OrderByDescending(a => a.IdeaUpdoots.Count()).ToList();
                        break;
                    case "LatestIdeas":
                        modelio.Ideas = modelio.Ideas.OrderByDescending(a => a.CreatedDate).ToList();
                        break;
                    case "PDCAIdeas":
                        modelio.Ideas = modelio.Ideas.OrderByDescending(a => a.PDCA).ToList();
                        break;
                    case "DivisionIdeas":
                        modelio.Ideas = modelio.Ideas.OrderBy(a => a.EIdeasUser.UserDivision.DivisionName).ToList();
                        break;
                    case "UnitIdeas":
                        modelio.Ideas = modelio.Ideas.OrderBy(a => a.EIdeasUser.UserUnit.UnitName).ToList();
                        break;
                    default:
                        break;
                }
            }


            return View("~/Ideas/Ideas.cshtml", modelio);
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
