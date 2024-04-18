using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ToolShopApplication.Services.Filter;
using ToolShopDomainCore.Domain.Entity;
using ToolShopDomainCore.Domain.Fileters;
using ToolShopInfrastructure.Services;

namespace Tool_Shop_MVC.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IEntityService<OperationRaport> _service;
        private readonly IFilterService<OperationRaport> _filterService;
        public AdministratorController(IEntityService<OperationRaport> service,IFilterService<OperationRaport> filterService)
        {
            _service = service;
            _filterService = filterService;
        }
        [Route("/Administrator")]
        public async Task<IActionResult> Index(Filters<OperationRaport> model)
        {       
            model.entity = await _service.GetListAsync();
          
            ViewBag.SortBy = model.SortBy;
            ViewBag.SortDirection = model.SortDirection;
            
            var filtered = await _filterService.AddFilters(model);

            return View(filtered);
        }
    }
}
