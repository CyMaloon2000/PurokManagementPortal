using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Data
{
    public class PersonVM
    {
        public Person? Person { get; set; }
        public IEnumerable<SelectListItem> GenderSelectList { get; set; }
        public IEnumerable<SelectListItem> MaritalStatusSelectList { get; set; }
        public IEnumerable<SelectListItem> NationalitySelectList { get; set; }
        public IEnumerable<SelectListItem> OccupationSelectList { get; set; }
        public IEnumerable<SelectListItem> ReligionSelectList { get; set; }
        public IEnumerable<SelectListItem> RelationshipSelectList { get; set; }
        public IEnumerable<SelectListItem> EducationalStatusLevelSelectList { get; set; }
        public IEnumerable<SelectListItem> GovernmentSubsidySelectList { get; set; }
        public IEnumerable<SelectListItem> PhilHealthSourceSelectList { get; set; }


    }
}
