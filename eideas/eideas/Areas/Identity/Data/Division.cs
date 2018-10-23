using eideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eideas.Areas.Identity.Data
{
    public class Division 
    {
        public Division(int did, string dname, DateTime cdate, ICollection<EIdeasUser> eusers)
        {
            DivisionId = did;
            DivisionName = dname;
            CreatedDate = cdate;
            EideasUsers = eusers;
        }

        public Division()
        {
        }
        public int DivisionId { get; set; }

        public string DivisionName { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<EIdeasUser> EideasUsers { get; set; }

        public ICollection<Unit> Units { get; set; }
    }

}
