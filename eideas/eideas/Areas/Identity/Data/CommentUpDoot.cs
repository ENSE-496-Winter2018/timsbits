using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class CommentUpDoot
    {
        public int IdeaCommentId { get; set; }

        public IdeaComment  IdeaComment { get; set; }

        public string Id { get; set; }

        public EIdeasUser EIdeasUser { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
