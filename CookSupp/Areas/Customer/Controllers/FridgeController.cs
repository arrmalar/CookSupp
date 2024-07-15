using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookSupp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class FridgeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FridgeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objRecipeList = _unitOfWork.RecipeRepository.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Step()
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
                TempData["success"] = "Recipe created successfully";
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
            var recipeToBeDeleted = _unitOfWork.RecipeRepository.Get(u => u.Id == id);

            if (recipeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.RecipeRepository.Remove(recipeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

    }
}
