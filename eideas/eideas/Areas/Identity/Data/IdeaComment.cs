using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class IdeaComment
    {
        public int IdeaCommentId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public EIdeasUser EIdeasUser { get; set; }

        public Idea Idea { get; set; }

        public ICollection<CommentUpDoot> CommentUpDoots { get; set; }



    }
}
