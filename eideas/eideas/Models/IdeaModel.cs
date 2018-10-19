using System;
using System.Collections.Generic;
using eideas.Areas.Identity.Data;

namespace eideas.Models
{
    public class IdeaModel
    {
        public Idea NewIdea { get; set; }
        public ICollection<Idea> Ideas { get; set; }
        public IdeaModel()
        {
        }
    }
}
