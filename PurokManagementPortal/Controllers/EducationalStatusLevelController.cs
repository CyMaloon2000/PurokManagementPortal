using Generic.Data;
using Generic.DataAccess;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class EducationalStatusLevelController : Controller
    {

        private readonly IUnitofWork _unitofWork;

        public EducationalStatusLevelController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (Request.Headers["x-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView();
            }

            return View();
        }

        public IActionResult Create(EducationalStatusLevel level) {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.EducationStatusLevelRepository.Add(level);
                    _unitofWork.Save();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception e)
            {

                return Json(new { success = false, error = $"Error Encounter: {e}" });
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var level = _unitofWork.EducationStatusLevelRepository.FirstOrDefault(q => q.EducationalStatusLevelId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(level);
            }

            return View(level);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var level = _unitofWork.EducationStatusLevelRepository.FirstOrDefault(q => q.EducationalStatusLevelId == id);
                if (level != null)
                {
                    _unitofWork.EducationStatusLevelRepository.Delete(level);
                    _unitofWork.Save();
                    return Json(new { success = true });
                }

                return Json(new { success = false, error = $"Unexpected Error Encounter. Please contact system administrator." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, error = $"Error Encounter: {e}" });
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            id = id ?? 0;
            var level = _unitofWork.EducationStatusLevelRepository.FirstOrDefault(q => q.EducationalStatusLevelId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(level);
            }

            return View(level);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EducationalStatusLevel level)
        {
            try
            {
                _unitofWork.EducationStatusLevelRepository.Update(level);
                _unitofWork.Save();
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, error = $"Error Encounter: {e}" });
            }
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
            var pagedData = _unitofWork.EducationStatusLevelRepository.GetList(filter: q => q.EducationalStatusLevelName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.EducationStatusLevelRepository.GetCount(filter: q => q.EducationalStatusLevelName.Contains(searchBy));

            return Json(new
            {
                draw = dataTableParamVM.draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = pagedData
            });
        }
    }
}
