using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PurokManagementPortal.Controllers
{
    public class PersonController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public PersonController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View(PersonVM(null));
        }

        [HttpPost]
        public JsonResult GetListJson(DataTableParamVM dataTableParamVM)
        {
            Thread.Sleep(700);
            string searchBy = (dataTableParamVM.search.value != null) ? dataTableParamVM.search.value : "";
            string sortBy = "";
            string sortDir = "";

            if (dataTableParamVM.order != null)
            {
                sortBy = dataTableParamVM.columns[dataTableParamVM.order[0].column].data;
                sortDir = dataTableParamVM.order[0].dir.ToLower();
            }
            var pagedData = _unitofWork.PersonRepository.GetList(filter: q => q.LastName.Contains(searchBy) || q.FirstName.Contains(searchBy) || q.MiddleName.Contains(searchBy), includeProperties:"Gender, MaritalStatus", iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.PersonRepository.GetCount(filter: q => q.LastName.Contains(searchBy) || q.FirstName.Contains(searchBy) || q.MiddleName.Contains(searchBy));

            return Json(new
            {
                draw = dataTableParamVM.draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = pagedData
            });
        }

        private PersonVM PersonVM(int? personId)
        {
            personId = personId ?? 0;
            Person person = _unitofWork.PersonRepository.FirstOrDefault(q => q.PersonId == personId);

            IEnumerable<SelectListItem> genderSelectList = _unitofWork.GenderRepository.GetListEnumerable(q => q.IsActive).Select(
                q => new SelectListItem
                {
                    Text = q.GenderName,
                    Value = q.GenderId.ToString()
                }
            );

            IEnumerable<SelectListItem> maritalStatusSelectList = _unitofWork.MaritalStatusRepository.GetListEnumerable(q => q.IsActive).Select(
                q => new SelectListItem
                {
                    Text = q.StatusName,
                    Value = q.MaritalStatusId.ToString()
                }
            );

            IEnumerable<SelectListItem> nationalitySelectList = _unitofWork.NationalityRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.NationalityName,
                   Value = q.NationalityId.ToString()
               }
            );

            IEnumerable<SelectListItem> occupationSelectList = _unitofWork.OccupationRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.OccupationName,
                   Value = q.OccupationId.ToString()
               }
            );

            IEnumerable<SelectListItem> religionSelectList = _unitofWork.ReligionRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.ReligionName,
                   Value = q.ReligionId.ToString()
               }
            );

            IEnumerable<SelectListItem> relationshipSelectList = _unitofWork.RelationshipRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.RelationshipName,
                   Value = q.RelationshipId.ToString()
               }
            );

            IEnumerable<SelectListItem> educationSelectList = _unitofWork.EducationStatusLevelRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.EducationalStatusLevelName,
                   Value = q.EducationalStatusLevelId.ToString()
               }
            );

            IEnumerable<SelectListItem> governmentSelectList = _unitofWork.GovernmentSubsidyRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.GovernmentSubsidyName,
                   Value = q.GovernmentSubsidyId.ToString()
               }
            );

            IEnumerable<SelectListItem> philHealthSelectList = _unitofWork.PhilHealthSoruceRepository.GetListEnumerable(q => q.IsActive).Select(
               q => new SelectListItem
               {
                   Text = q.PhilHealthSourceName,
                   Value = q.PhilHealthSourceId.ToString()
               }
            );

            PersonVM personVM = new PersonVM()
            {
                Person = person,
                GenderSelectList = genderSelectList,
                MaritalStatusSelectList = maritalStatusSelectList,
                NationalitySelectList = nationalitySelectList,
                OccupationSelectList = occupationSelectList,
                ReligionSelectList = religionSelectList,
                RelationshipSelectList = relationshipSelectList,
                EducationalStatusLevelSelectList = educationSelectList,
                GovernmentSubsidySelectList = governmentSelectList,
                PhilHealthSourceSelectList = philHealthSelectList
            };

            return personVM;
        }
    }
}
