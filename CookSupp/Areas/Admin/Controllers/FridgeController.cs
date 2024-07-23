using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using CookSupp.Models.ViewModels;
using CookSupp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace CookSupp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class FridgeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public FridgeController(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
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
            var fridge = new Fridge
            {
                FridgeProducts = new List<FridgeProduct>()
            };

            SaveFridgeProductsNamesToCache(new List<FridgeProduct>());

            return View(fridge);
        }

        [HttpPost]
        public IActionResult Create(Fridge fridge)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            fridge.FridgeProducts = GetFridgeProductsNamesFromCache();

            _unitOfWork.FridgeRepository.Add(fridge);
            _unitOfWork.Save();
            TempData["success"] = "Fridge created successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var fridge = _unitOfWork.FridgeRepository.Get(p => p.Id == id, includeProperties: "ApplicationUser,FridgeProducts");
            var fridgeProducts = fridge.FridgeProducts.Select(fp => fp.ProductId ).ToList();

            if (fridge != null)
            {
                var model = new FridgeVM
                {
                    Fridge = fridge,
                    SelectedProductsIds = fridgeProducts
                };

                SaveFridgeProductsNamesToCache(fridge.FridgeProducts.ToList());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Fridge fridge)
        {
            if (!ModelState.IsValid)
            {
                return View(fridge);
            }

            if (fridge != null)
            {
                fridge.FridgeProducts = new List<FridgeProduct>();

                foreach (var product in GetFridgeProductsNamesFromCache()) {
                    fridge.FridgeProducts.Add(new FridgeProduct
                    {
                        ProductId = product.ProductId,
                        FridgeId = product.FridgeId
                    });
                }

                _unitOfWork.FridgeRepository.Update(fridge);
                _unitOfWork.Save();
            }

            TempData["success"] = "Fridge edited successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objFridgeList = _unitOfWork.FridgeRepository.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = objFridgeList });
        }

        public IActionResult Delete(int? id)
        {
            var fridgeToBeDeleted = _unitOfWork.FridgeRepository.Get(u => u.Id == id);

            if (fridgeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.FridgeRepository.Remove(fridgeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult AddProduct(int productId,int fridgeId)
        {
            var fridgeProduct = new FridgeProduct
            {
                FridgeId = fridgeId,
                ProductId = productId,
            };
            var products = GetFridgeProductsNamesFromCache();
            products.Add(fridgeProduct);
            SaveFridgeProductsNamesToCache(products);
            
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveProduct(int productId, int fridgeId)
        {
            var fridgeProduct = new FridgeProduct
            {
                FridgeId = fridgeId,
                ProductId = productId,
            };
            var products = GetFridgeProductsNamesFromCache();
            var productToRemove = products.FirstOrDefault(p => p.ProductId == productId && p.FridgeId == fridgeId);

            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }

            SaveFridgeProductsNamesToCache(products);

            return Ok();
        }

        private List<FridgeProduct> GetFridgeProductsNamesFromCache()
        {
            return _memoryCache.GetOrCreate("FridgeProductsNames", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(30);
                return new List<FridgeProduct>();
            });
        }

        private void SaveFridgeProductsNamesToCache(List<FridgeProduct> products)
        {
            _memoryCache.Set("FridgeProductsNames", products, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            });
        }
    }
}
