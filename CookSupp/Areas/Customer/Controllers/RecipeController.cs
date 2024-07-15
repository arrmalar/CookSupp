using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using CookSupp.Models.ViewModels;
using CookSupp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace CookSupp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;
        public RecipeController(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var recipe = new Recipe
            {
                ApplicationUserId = userId,
                Approved = false
            };

            SaveRecipeProductsNamesToCache(new List<RecipeProduct>());

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            recipe.RecipeProducts = GetRecipeProductsNamesFromCache();

            _unitOfWork.RecipeRepository.Add(recipe);
            _unitOfWork.Save();
            TempData["success"] = "Recipe created successfully";
            return RedirectToAction("Index");
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

        [HttpPost]
        public IActionResult AddProduct(int productId, int recipeId)
        {
            var recipeProduct = new RecipeProduct
            {
                RecipeId = recipeId,
                ProductId = productId,
            };
            var products = GetRecipeProductsNamesFromCache();
            products.Add(recipeProduct);
            SaveRecipeProductsNamesToCache(products);

            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveProduct(int productId, int recipeId)
        {
            var recipeProduct = new RecipeProduct
            {
                RecipeId = recipeId,
                ProductId = productId,
            };
            var products = GetRecipeProductsNamesFromCache();
            var productToRemove = products.FirstOrDefault(p => p.ProductId == productId && p.RecipeId == recipeId);

            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }

            SaveRecipeProductsNamesToCache(products);

            return Ok();
        }

        private List<RecipeProduct> GetRecipeProductsNamesFromCache()
        {
            return _memoryCache.GetOrCreate("RecipeProductsNames", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(30);
                return new List<RecipeProduct>();
            });
        }

        private void SaveRecipeProductsNamesToCache(List<RecipeProduct> products)
        {
            _memoryCache.Set("RecipeProductsNames", products, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            });
        }
    }
}
