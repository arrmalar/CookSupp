using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using CookSupp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CookSupp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var searchDataVM = new SearchDataVM
            {
                Text = "",
                SearchedRecipes = _unitOfWork.RecipeRepository.GetAll().ToList(),
                SelectedProductsIds = new List<int>()
            };

            SaveProductsToCache(new List<Product>());

            return View(searchDataVM);
        }

        [HttpPost]
        public IActionResult Index(SearchDataVM searchDataVM)
        {
            searchDataVM.SearchedRecipes = _unitOfWork.RecipeRepository.GetAll(includeProperties: "RecipeProducts").ToList();
            var products = GetProductsFromCache();

            if (!string.IsNullOrEmpty(searchDataVM.Text)) 
            {
                var recipesFilteredByTitle = searchDataVM.SearchedRecipes.Where(r => r.Title.Contains(searchDataVM.Text)).ToList();
                var recipesFilteredByDescription = searchDataVM.SearchedRecipes.Where(r => r.Description.Contains(searchDataVM.Text)).ToList();
                recipesFilteredByDescription.AddRange(recipesFilteredByTitle);

                var output = new SortedSet<Recipe>();

                foreach (var item in recipesFilteredByDescription) 
                {
                    output.Add(item);
                }

                searchDataVM.SearchedRecipes = output.ToList();
            }

            if(products.Any())
            {
                var output = new List<Recipe>();

                foreach (var recipe in searchDataVM.SearchedRecipes)
                {
                    var exist = false;
                    foreach (var product in GetProductsFromCache())
                    {
                        exist = exist || (recipe.RecipeProducts.FirstOrDefault(r => r.ProductId == product.Id) != null);
                    }

                    if (exist)
                    {
                        output.Add(recipe);
                    }
                }

                searchDataVM.SearchedRecipes = output;
            }

            searchDataVM.SelectedProductsIds = GetProductsFromCache().Select(p => p.Id).ToList();

            return View(searchDataVM);
        }

        [HttpPost]
        public IActionResult AddProduct(int productId)
        {
            var product = _unitOfWork.ProductRepository.Get(p => p.Id == productId);

            if (product != null)
            {
                var products = GetProductsFromCache();
                products.Add(product);
                SaveProductsToCache(products);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveProduct(int productId)
        {
            var products = GetProductsFromCache();
            var productToRemove = products.FirstOrDefault(p => p.Id == productId);

            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }

            SaveProductsToCache(products);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var objProductList = _unitOfWork.ProductRepository.GetAll().ToList();
            return Json(new { data = objProductList });
        }

        private List<Product> GetProductsFromCache()
        {
            return _memoryCache.GetOrCreate("SearchProductsNames", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(30);
                return new List<Product>();
            });
        }

        private void SaveProductsToCache(List<Product> products)
        {
            _memoryCache.Set("SearchProductsNames", products, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
