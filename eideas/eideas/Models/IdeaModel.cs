using System;
using System.Collections.Generic;
using eideas.Areas.Identity.Data;
using eideas.Data;

using Microsoft.AspNetCore.Identity;

namespace eideas.Models
{
    public class IdeaModel
    {
        public Idea NewIdea { get; set; }
        public IdeaComment NewComment {get; set;}
        public ICollection<Idea> Ideas { get; set; }
        public ICollection<EIdeasUser> Users {get; set;} 
        public ICollection<Division> Divisions {get; set;} 
        public ICollection<Unit> Units {get; set;} 
        public IdeaModel()
        {
        }
    }
}
