using BulkyBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using BulkyBook.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Company company = new();

            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefualt(o => o.Id == id);
                return View(company);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Company Created Successfully!";
                }

                else        
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Company Created Successfully!";
                }

                _unitOfWork.Save();


                return RedirectToAction("Index");
            }

            return View(company);
        }


        #region API Calls
        [HttpGet]
        public IActionResult getAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleted = _unitOfWork.Company.GetFirstOrDefualt(c => c.Id == id);

            if (deleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting!" });
            }
            
            _unitOfWork.Company.Remove(deleted);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });
        }
        #endregion
    }
}
