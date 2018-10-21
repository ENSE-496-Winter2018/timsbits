using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace eideas.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }

        public List<SelectListItem> LstDivision { get; set; }

    }
}
