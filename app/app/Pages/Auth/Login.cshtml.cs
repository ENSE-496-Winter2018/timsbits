using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages.Auth
{
    public class LoginModel : PageModel
    {
        public string Email { get; set; }
        public void OnGet()
        {
        }

        //public IAsyncResult OnPostAsync() {

        //    return null;
        //}
    }
}
