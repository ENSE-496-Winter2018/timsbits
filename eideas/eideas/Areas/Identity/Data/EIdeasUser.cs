using System;
using Microsoft.AspNetCore.Identity;

namespace eideas.Models
{
    public class EIdeasUser : IdentityUser
    {
        [PersonalData]
        public String Organization { get; set; }


        public EIdeasUser()
        {
        }
    }
}
