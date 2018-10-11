using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class IdeaSubscription
    {
        public int IdeaId { get; set; }

        public Idea Idea { get; set; }

        public string Id { get; set; }
        public EIdeasUser EideasUser { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
