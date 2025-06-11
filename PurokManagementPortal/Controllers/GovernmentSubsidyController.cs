using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class GovernmentSubsidyController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public GovernmentSubsidyController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
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
        public IActionResult Create(GovernmentSubsidy subsidy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.GovernmentSubsidyRepository.Add(subsidy);
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
            var subsidy = _unitofWork.GovernmentSubsidyRepository.FirstOrDefault(q => q.GovernmentSubsidyId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(subsidy);
            }

            return View(subsidy);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var subsidy = _unitofWork.GovernmentSubsidyRepository.FirstOrDefault(q => q.GovernmentSubsidyId == id);
                if (subsidy != null)
                {
                    _unitofWork.GovernmentSubsidyRepository.Delete(subsidy);
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
            var subsidy = _unitofWork.GovernmentSubsidyRepository.FirstOrDefault(q => q.GovernmentSubsidyId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(subsidy);
            }

            return View(subsidy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GovernmentSubsidy subsidy)
        {
            try
            {
                _unitofWork.GovernmentSubsidyRepository.Update(subsidy);
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
            string searchBy = ""; /*(dataTableParamVM.search != null) ? dataTableParamVM.search.value : dataTableParamVM.search.value*/
            string sortBy = "";
            string sortDir = "";

            if (dataTableParamVM.order.Count != 0)
            {
                // in this example we just default sort on the 1st column
                sortBy = dataTableParamVM.columns[dataTableParamVM.order[0].column].data;
                sortDir = dataTableParamVM.order[0].dir.ToLower();
            }

            var pagedData = _unitofWork.GovernmentSubsidyRepository.GetList(filter: q => q.GovernmentSubsidyName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.GovernmentSubsidyRepository.GetCount(filter: q => q.GovernmentSubsidyName.Contains(searchBy));

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
