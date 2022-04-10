using BulkyBook.DataAccess;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer Name", "The Customer name must be different from the display order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);

                _unitOfWork.Save();

                TempData["success"] = "Category Created Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefualt(c => c.Id == id);
            
            if(categoryFromDb == null)
            {   
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer Name", "The Customer name must be different from the display order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);

                _unitOfWork.Save();

                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete (int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var category = _unitOfWork.Category.GetFirstOrDefualt(c => c.Id == Id);
            
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {

            var deleted = _unitOfWork.Category.GetFirstOrDefualt(c => c.Id == Id);

            if (deleted == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(deleted);

            _unitOfWork.Save();

            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}