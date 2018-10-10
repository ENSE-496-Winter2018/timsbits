using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class Unit
    {

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<EIdeasUser> EideasUsers { get; set; }
    }
}
