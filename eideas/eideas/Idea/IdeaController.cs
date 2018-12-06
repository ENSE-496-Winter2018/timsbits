using System;
using System.Linq;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

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

        [Route("Idea/{ideaId:int}")]
        public IActionResult Index(int ideaId) {
            if (ideaId == -1) {
                return Redirect("/Ideas");
            }

            Idea idea = db.Ideas
                          .Include(i => i.EIdeasUser)
                          .Include(i => i.IdeaUpdoots)                          
                          .Include(i => i.IdeaComments)                          
                            .ThenInclude(ic => ic.EIdeasUser)
                          .First(i => i.IdeaId == ideaId);

            idea.IdeaComments = db.IdeaComments.Where(a => a.IdeaId == idea.IdeaId).Include(i=> i.CommentUpDoots).ToList();

            return View("~/Idea/Idea.cshtml", idea);
        }

        [Authorize]
        [HttpPost]
        [Route("Idea/{ideaId:int}/Comment")]
        public async Task<IActionResult> CreateComment(IdeaComment ideaComment, int ideaId)
        {
            var uid = userManager.GetUserId(HttpContext.User);
            EIdeasUser user = await userManager.FindByIdAsync(uid);

            Idea idea = db.Ideas.First(i => i.IdeaId == ideaId);

            ideaComment.EIdeasUser = user;

            idea.IdeaComments.Add(ideaComment);
            db.SaveChanges();

            return RedirectToAction("Index", ideaId);
        }

        [Authorize]
        [HttpPost]
        [Route("Idea/{ideaId:int}/EditIdea")]
        public IActionResult EditIdea(Idea editedIdea, int ideaId)
        {
            var entity = db.Ideas.FirstOrDefault(item => item.IdeaId == ideaId);
            entity.IdeaName = editedIdea.IdeaName;
            entity.IdeaContent = editedIdea.IdeaContent;
            db.Ideas.Update(entity);
            db.SaveChanges();
          return Redirect("/Idea/"+ideaId);
        }

        [Authorize]
        [HttpPost]
        [Route("Idea/{ideaId:int}/PDCAIdea")]
        public IActionResult PDCAIdea(int ideaId)
        {
            var entity = db.Ideas.FirstOrDefault(item => item.IdeaId == ideaId);
            if (entity.PDCA != PDCA.done)
            {
            entity.PDCA = (PDCA)(1 + (int)entity.PDCA);
            }
            db.Ideas.Update(entity);
            db.SaveChanges();
          return Redirect("/Idea/"+ideaId);
        }

        [Authorize]
        [HttpPost]
        [Route("Idea/{ideaId:int}/DeleteIdea")]
        public IActionResult DeleteIdea(int ideaId)
        {
            db.IdeaComments.Where(p => p.IdeaId == ideaId).ToList().ForEach(p => db.IdeaComments.Remove(p));
            db.SaveChanges();
            var entity = db.Ideas.FirstOrDefault(item => item.IdeaId == ideaId);
            db.Ideas.Remove(entity);
            db.SaveChanges();
          return Redirect("/Ideas");
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


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpvoteComment([FromBody] int ideaCommentId)
        {
            var uid = userManager.GetUserId(HttpContext.User);
            EIdeasUser user = await userManager.FindByIdAsync(uid);

            IdeaComment ideaComment = db.IdeaComments.First(a=> a.IdeaCommentId == ideaCommentId);

            CommentUpDoot commentUpDoot = new CommentUpDoot
            {
                IdeaCommentId = ideaCommentId,
                EIdeasUser = user,
                CreatedDate = DateTime.Now
            };

            ideaComment.CommentUpDoots.Add(commentUpDoot);
            db.SaveChanges();

            return StatusCode(200);
        }

    }
}
