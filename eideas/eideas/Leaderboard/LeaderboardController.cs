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
            ICollection<EIdeasUser> localUsers = db.Users.Include(i => i.UserDivision).ToList();
            ICollection<Idea> localIdeas = db.Ideas.Include(i => i.IdeaUpdoots).ToList();
            ICollection<IdeaComment> localComments = db.IdeaComments.Include(i => i.CommentUpDoots).Include(i => i.EIdeasUser).ToList();
            ICollection<Division> localDivisions = db.Divisions.Include(i => i.EideasUsers).ToList();
            ICollection<Unit> localUnits = db.Units.Include(i => i.EideasUsers).ToList();
            List<LeaderboardModel> list = new List<LeaderboardModel>();

            
                switch (filter)
                {
                    
                    case "TopDivision":
                        foreach (Division division in localDivisions)
                        {
                            int divPoints = 0;
                            foreach (EIdeasUser newName in localUsers)
                            {
                                foreach (var idea in localIdeas)
                                {
                                   if (idea.CreatedBy == newName.UserName && newName.UserDivisionDivisionId == division.DivisionId)
                                    {
                                         divPoints += idea.IdeaUpdoots.Count();
                                    }
                                }
                                foreach (var comment in localComments)
                                {
                                    if (comment.EIdeasUser.UserName == newName.UserName && newName.UserDivisionDivisionId == division.DivisionId)
                                    {
                                         divPoints += comment.CommentUpDoots.Count();
                                    }
                                }
                            }
                            list.Add(new LeaderboardModel(divPoints, division.DivisionName));
                        }
                        break;
                    case "TopUnit":
                        foreach (Unit unit in localUnits)
                        {
                            int unitPoints = 0;
                            foreach (EIdeasUser newName in localUsers)
                            {
                                foreach (var idea in localIdeas)
                                {
                                   if (idea.CreatedBy == newName.UserName && newName.UserUnitUnitId == unit.UnitId)
                                    {
                                         unitPoints += idea.IdeaUpdoots.Count();
                                    }
                                }
                                foreach (var comment in localComments)
                                {
                                    if (comment.EIdeasUser.UserName == newName.UserName && newName.UserUnitUnitId == unit.UnitId)
                                    {
                                         unitPoints += comment.CommentUpDoots.Count();
                                    }
                                }
                            }
                            list.Add(new LeaderboardModel(unitPoints, unit.UnitName));
                        }
                        break;
                    case "TopUser":
                    default:
                       foreach (EIdeasUser newName in localUsers)
                        {
                            int userPoints = 0;

                            //Get Idea Points
                            foreach (var idea in localIdeas)
                            {
                                 if (idea.CreatedBy == newName.UserName)
                                {
                                     userPoints += idea.IdeaUpdoots.Count();
                                 }
                            }
                            foreach (var comment in localComments)
                            {
                                if (comment.EIdeasUser.UserName == newName.UserName)
                                {
                                     userPoints += comment.CommentUpDoots.Count();
                                }
                            }
                            list.Add(new LeaderboardModel(userPoints, newName.NormalizedEmail));
                        }
                        break;
                }

            ICollection<LeaderboardModel> modelio = list;
            modelio = modelio.OrderByDescending(a => a.points).ToList();
            return View("~/Leaderboard/Leaderboard.cshtml", modelio);
        }


    }
}
