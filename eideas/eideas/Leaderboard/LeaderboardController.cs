using System.Collections.Generic;
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
    public class LeaderboardController : Controller
    {
        readonly ApplicationDbContext db;
        readonly UserManager<EIdeasUser> userManager;
 
        public LeaderboardController(ApplicationDbContext context, UserManager<EIdeasUser> _userManager)
        {
            db = context;
            userManager = _userManager;
        }

        [Authorize]
        public IActionResult Index(string filter)
        {

            ICollection<Idea> ideas = db.Ideas.Include(i => i.IdeaUpdoots).ToList();

            if (filter != null)
            {
                switch (filter)
                {
                    case "TopUser":
                        ideas = ideas.OrderByDescending(a => a.IdeaUpdoots.Count()).ToList();
                        break;
                    case "TopDivision":
                        ideas = ideas.OrderByDescending(a => a.CreatedDate).ToList();
                        break;
                    case "TopUnit":
                        ideas = ideas.OrderByDescending(a => a.PDCA).ToList();
                        break;
                    default:
                        break;
                }
            }


            return View("~/Leaderboard/Leaderboard.cshtml", ideas);
        }


    }
}
