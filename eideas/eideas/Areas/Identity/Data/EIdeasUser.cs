using Microsoft.AspNetCore.Identity;

namespace eideas.Areas.Identity.Data
{
    public class EIdeasUser : IdentityUser
    {
        
        public EIdeasUser()
        {
        }

        public Division UserDivision {get; set;}

        public Unit UserUnit {get; set;}      

        public Team Team { get; set; }
    }
}
