using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class Unit
    {
        public Unit(int uid, string uname, DateTime cdate, ICollection<EIdeasUser> eusers)
        {
            UnitId = uid;
            UnitName = uname;
            CreatedDate = cdate;
            EideasUsers = eusers;
        }

        public Unit()
        {
        }
        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<EIdeasUser> EideasUsers { get; set; }
    }
}
