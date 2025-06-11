using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PurokManagementPortal.Controllers
{
    public class GenderController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public GenderController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") {
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
        public IActionResult Create(Gender gender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.GenderRepository.Add(gender);
                    _unitofWork.Save();
                    return Json(new { success = true });
                }
                else { 
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
            var gender = _unitofWork.GenderRepository.FirstOrDefault(q => q.GenderId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(gender);
            }

            return View(gender);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var gender = _unitofWork.GenderRepository.FirstOrDefault(q => q.GenderId == id);
                if (gender != null)
                {
                    _unitofWork.GenderRepository.Delete(gender);
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
            var gender = _unitofWork.GenderRepository.FirstOrDefault(q => q.GenderId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(gender);
            }

            return View(gender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Gender gender) 
        {
            try
            {
                _unitofWork.GenderRepository.Update(gender);
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

            var pagedData = _unitofWork.GenderRepository.GetList(filter: q => q.GenderName.Contains(searchBy),iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.GenderRepository.GetCount(filter: q => q.GenderName.Contains(searchBy));

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
