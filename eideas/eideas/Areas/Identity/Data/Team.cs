using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class Team
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }

        public EIdeasUser TeamManager { get; set; }
    }
}
