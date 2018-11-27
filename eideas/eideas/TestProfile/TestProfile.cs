using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System;
using System.Web;
using System.Web.Mvc;

namespace eideas.NewFolder
{
    public class TestProfileController : Controller
    {
        readonly ApplicationDbContext db;
        readonly UserManager<EIdeasUser> userManager;

        public TestProfileController(ApplicationDbContext context, UserManager<EIdeasUser> _userManager)
        {
            db = context;
            userManager = _userManager;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Profile()
        {
            ViewBag.Message = "Update your profile";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
public ActionResult Profile(HttpPostedFileBase Profile)
{
  
            var uid = userManager.GetUserId(HttpContext.User);
            EIdeasUser user = await userManager.FindByIdAsync(uid);

    // convert image stream to byte array
    byte[] image = new byte[Profile.ContentLength];
    Profile.InputStream.Read(image, 0, Convert.ToInt32(Profile.ContentLength));

    user.ProfilePicture = image;

    // save changes to database
    db.SaveChanges();

    return RedirectToAction("Index", "Home");
}
        public FileContentResult Photo(string userId)
        {
            var uid = userManager.GetUserId(HttpContext.User);
            EIdeasUser user = await userManager.FindByIdAsync(uid);
            return new FileContentResult(user.ProfilePicture, "image/jpeg");
        }
    }
}
