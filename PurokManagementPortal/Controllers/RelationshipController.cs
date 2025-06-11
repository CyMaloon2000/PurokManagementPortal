using Generic.Data;
using Generic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PurokManagementPortal.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public RelationshipController(IUnitofWork unitofWork)
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
        public IActionResult Create(Relationship relationship)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.RelationshipRepository.Add(relationship);
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
            var relationship = _unitofWork.RelationshipRepository.FirstOrDefault(q => q.RelationshipId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(relationship);
            }

            return View(relationship);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            try
            {
                id = id ?? 0;
                var relationship = _unitofWork.RelationshipRepository.FirstOrDefault(q => q.RelationshipId == id);
                if (relationship != null)
                {
                    _unitofWork.RelationshipRepository.Delete(relationship);
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
            var relationship = _unitofWork.RelationshipRepository.FirstOrDefault(q => q.RelationshipId == id);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(relationship);
            }

            return View(relationship);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Relationship relationship)
        {
            try
            {
                _unitofWork.RelationshipRepository.Update(relationship);
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

            var pagedData = _unitofWork.RelationshipRepository.GetList(filter: q => q.RelationshipName.Contains(searchBy), iDisplayStart: dataTableParamVM.start, iDisplayLength: dataTableParamVM.length, sortProperty: sortBy, sortOrder: sortDir);
            var totalRecords = _unitofWork.RelationshipRepository.GetCount(filter: q => q.RelationshipName.Contains(searchBy));

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
