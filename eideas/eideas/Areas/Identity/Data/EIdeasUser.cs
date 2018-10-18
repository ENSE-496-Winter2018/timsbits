using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


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

        public ICollection<IdeaComment> IdeaComments { get; set; }

        public ICollection<IdeaSubscription> IdeaSubscriptions { get; set; }

        public ICollection<IdeaUpDoot> IdeaUpdoots { get; set; }

        public ICollection<CommentUpDoot> CommentUpDoots { get; set; }
    }
}
