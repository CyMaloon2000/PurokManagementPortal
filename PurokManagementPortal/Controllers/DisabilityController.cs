using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class DisabilityController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public DisabilityController(IUnitofWork unitofWork)
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
        public IActionResult Create(Disability disability)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.DisabilityRepository.Add(disability);
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
            var disability = _unitofWork.DisabilityRepository.FirstOrDefault(q => q.DisabilityId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(disability);
            }

            return View(disability);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var disability = _unitofWork.DisabilityRepository.FirstOrDefault(q => q.DisabilityId == id);
                if (disability != null)
                {
                    _unitofWork.DisabilityRepository.Delete(disability);
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
            var disability = _unitofWork.DisabilityRepository.FirstOrDefault(q => q.DisabilityId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(disability);
            }

            return View(disability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Disability disability)
        {
            try
            {
                _unitofWork.DisabilityRepository.Update(disability);
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
            var pagedData = _unitofWork.DisabilityRepository.GetList(filter: q => q.DisabilityName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.DisabilityRepository.GetCount(filter: q => q.DisabilityName.Contains(searchBy));

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
