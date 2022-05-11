using BulkyBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            IEnumerable<CoverType> covers = _unitOfWork.CoverType.GetAll();

            return View(covers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(coverType);
                
                _unitOfWork.Save();

                TempData["success"] = "Cover Type Created Successfully!";

                return RedirectToAction("Index");
            }
            return View(coverType);
                
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var cover = _unitOfWork.CoverType.GetFirstOrDefualt(c => c.Id == id);
            
            if(cover == null)
            {
                return NotFound();
            }

            return View(cover);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType cover)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(cover);
                
                _unitOfWork.Save();

                TempData["success"] = "Cover Updated Successfully!";

                return RedirectToAction("Index");
            }

            return View(cover);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var cover = _unitOfWork.CoverType.GetFirstOrDefualt(c => c.Id == id);

            if(cover == null)
            {
                return NotFound();
            }

            return View(cover);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var deleted = _unitOfWork.CoverType.GetFirstOrDefualt(c => c.Id == id);

            if (deleted == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(deleted);

            _unitOfWork.Save();

            TempData["success"] = "Cover Type Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
