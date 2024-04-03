using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tool_Shop_MVC.Models;
using ToolShopApplication.DataBase;
using ToolShopDomainCore.Domain.Entity;
using ToolShopInfrastructure.Services;

namespace Tool_Shop_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<ToolProfile> _entityService;

        public HomeController(ILogger<HomeController> logger, IEntityService<ToolProfile> entityService)
        {
            _logger = logger;
            _entityService = entityService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _entityService.GetListAsync(); 
            return View(model.Value);
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
