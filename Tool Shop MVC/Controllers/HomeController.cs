using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tool_Shop_MVC.Models;
using ToolShopApplication.CQRS.Command.CreateEntity;
using ToolShopApplication.CQRS.Queries.GetAll;
using ToolShopApplication.DataBase;
using ToolShopApplication.DataTransferObject;
using ToolShopDomainCore.Domain.Entity;
using ToolShopInfrastructure.Services;

namespace Tool_Shop_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<ToolProfile> _entityService;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IEntityService<ToolProfile> entityService,IMediator mediator)
        {
            _logger = logger;
            _entityService = entityService;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new GetAllQuery<ToolProfile, ToolProfileDto>());
            return View(model);
        }
        public IActionResult AddTool() 
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddModal([FromForm]ToolProfileRequest request)
        {
            await _mediator.Send(new CreateEntityCommand<ToolProfile, ToolProfileRequest>(request));

            return RedirectToAction("Index");

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
