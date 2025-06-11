using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class NationalityController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public NationalityController(IUnitofWork unitofWork)
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
        public IActionResult Create(Nationality nationality)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.NationalityRepository.Add(nationality);
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
            var nationality = _unitofWork.NationalityRepository.FirstOrDefault(q => q.NationalityId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(nationality);
            }

            return View(nationality);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var nationality = _unitofWork.NationalityRepository.FirstOrDefault(q => q.NationalityId == id);
                if (nationality != null)
                {
                    _unitofWork.NationalityRepository.Delete(nationality);
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
            var nationality = _unitofWork.NationalityRepository.FirstOrDefault(q => q.NationalityId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(nationality);
            }

            return View(nationality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Nationality nationality)
        {
            try
            {
                _unitofWork.NationalityRepository.Update(nationality);
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

            var pagedData = _unitofWork.NationalityRepository.GetList(filter: q => q.NationalityName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.NationalityRepository.GetCount(filter: q => q.NationalityName.Contains(searchBy));

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
