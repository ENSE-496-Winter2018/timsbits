using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class Idea
    {

        public int IdeaId { get; set; }

        public string IdeaName { get; set; }

        public string IdeaContent { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        //public virtual ICollection<IdeaComment> IdeaComments { get; set; }
    }
}
