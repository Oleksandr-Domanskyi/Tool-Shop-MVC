using Microsoft.AspNetCore.Mvc;
using ToolShopDomainCore.Domain.Entity;
using ToolShopInfrastructure.Services;

namespace Tool_Shop_MVC.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IEntityService<OperationRaport> _service;

        public AdministratorController(IEntityService<OperationRaport> service)
        {
            _service = service;
        }
        [Route("/Administrator")]
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetListAsync();

            return View(model.Value);
        }
    }
}
