using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookSupp.Areas.Customer.Controllers
{
    [Area("Sandbox")]
    public class SandboxController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SandboxController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Partial()
        {
            return View();
        }
    }
}
