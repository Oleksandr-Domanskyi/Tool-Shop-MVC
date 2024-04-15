using Microsoft.AspNetCore.Mvc;
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
        public Filters Filters { get; set; }

        public AdministratorController(IEntityService<OperationRaport> service,IFilterService<OperationRaport> filterService)
        {
            _service = service;
            _filterService = filterService;
        }
        [Route("/Administrator")]
        public async Task<IActionResult> Index(Filters filters)
        {       
            var model = await _service.GetListAsync();
            var filtered = await _filterService.AddFilters(model.Value,filters);
            return View(filtered);
        }
    }
}
