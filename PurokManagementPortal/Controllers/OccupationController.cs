using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class OccupationController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public OccupationController(IUnitofWork unitofWork)
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
        public IActionResult Create(Occupation occupation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.OccupationRepository.Add(occupation);
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
            var occupation = _unitofWork.OccupationRepository.FirstOrDefault(q => q.OccupationId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(occupation);
            }

            return View(occupation);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var occupation = _unitofWork.OccupationRepository.FirstOrDefault(q => q.OccupationId == id);
                if (occupation != null)
                {
                    _unitofWork.OccupationRepository.Delete(occupation);
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
            var occupation = _unitofWork.OccupationRepository.FirstOrDefault(q => q.OccupationId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(occupation);
            }

            return View(occupation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Occupation occupation)
        {
            try
            {
                _unitofWork.OccupationRepository.Update(occupation);
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

            var pagedData = _unitofWork.OccupationRepository.GetList(filter: q => q.OccupationName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.OccupationRepository.GetCount(filter: q => q.OccupationName.Contains(searchBy));

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
