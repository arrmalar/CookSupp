using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using CookSupp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookSupp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class RecipeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecipeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objRecipeList = _unitOfWork.RecipeRepository.GetAll();
            return View(objRecipeList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RecipeRepository.Add(recipe);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var recipe = _unitOfWork.RecipeRepository.Get(p => p.Id == id);

            if (recipe != null)
            {
                return View(recipe);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Recipe? recipe)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RecipeRepository.Update(recipe);
                _unitOfWork.Save();
                TempData["success"] = "Recipe edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objRecipeList = _unitOfWork.RecipeRepository.GetAll().ToList();
            return Json(new { data = objRecipeList });
        }

        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.ProductRepository.Get(u => u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.ProductRepository.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
