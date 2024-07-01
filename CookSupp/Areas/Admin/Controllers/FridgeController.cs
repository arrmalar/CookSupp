using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using CookSupp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace CookSupp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class FridgeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FridgeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objFridgeList = _unitOfWork.FridgeRepository.GetAll();
            return View(objFridgeList);
        }

        public IActionResult Create()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var fridge = new Fridge
            {
                ApplicationUserId = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userId).Id,
                FridgeProducts = new List<FridgeProduct>()
            };

            return View(fridge);
        }

        [HttpPost]
        public IActionResult Create(Fridge fridge)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FridgeRepository.Add(fridge);
                _unitOfWork.Save();
                TempData["success"] = "Fridge created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var fridge = _unitOfWork.FridgeRepository.Get(p => p.Id == id);

            if (fridge != null)
            {
                return View(fridge);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Fridge? fridge)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FridgeRepository.Update(fridge);
                _unitOfWork.Save();
                TempData["success"] = "Fridge edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objFridgeList = _unitOfWork.FridgeRepository.GetAll().ToList();
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
    }
}
