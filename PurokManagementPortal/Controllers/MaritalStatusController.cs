using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class MaritalStatusController : Controller
    {
        public readonly IUnitofWork _unitofWork;

        public MaritalStatusController(IUnitofWork unitofWork)
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
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(MaritalStatus status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.MaritalStatusRepository.Add(status);
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
            var status = _unitofWork.MaritalStatusRepository.FirstOrDefault(q => q.MaritalStatusId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(status);
            }

            return View(status);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var status = _unitofWork.MaritalStatusRepository.FirstOrDefault(q => q.MaritalStatusId == id);
                if (status != null)
                {
                    _unitofWork.MaritalStatusRepository.Delete(status);
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
            var status = _unitofWork.MaritalStatusRepository.FirstOrDefault(q => q.MaritalStatusId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(status);
            }

            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MaritalStatus status)
        {
            try
            {
                _unitofWork.MaritalStatusRepository.Update(status);
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
            var pagedData = _unitofWork.MaritalStatusRepository.GetList(filter: q => q.StatusName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.MaritalStatusRepository.GetCount(filter: q => q.StatusName.Contains(searchBy));

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
