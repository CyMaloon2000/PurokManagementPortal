using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class ReligionController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public ReligionController(IUnitofWork unitofWork)
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
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Religion religion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.ReligionRepository.Add(religion);
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
            var religion = _unitofWork.ReligionRepository.FirstOrDefault(q => q.ReligionId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(religion);
            }

            return View(religion);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var religion = _unitofWork.ReligionRepository.FirstOrDefault(q => q.ReligionId == id);
                if (religion != null)
                {
                    _unitofWork.ReligionRepository.Delete(religion);
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
            var religion = _unitofWork.ReligionRepository.FirstOrDefault(q => q.ReligionId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(religion);
            }

            return View(religion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Religion religion)
        {
            try
            {
                _unitofWork.ReligionRepository.Update(religion);
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
                // in this example we just default sort on the 1st column
                sortBy = dataTableParamVM.columns[dataTableParamVM.order[0].column].data;
                sortDir = dataTableParamVM.order[0].dir.ToLower();
            }
            var pagedData = _unitofWork.ReligionRepository.GetList(filter: q => q.ReligionName.Contains(searchBy),iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.ReligionRepository.GetCount(filter: q => q.ReligionName.Contains(searchBy));

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
