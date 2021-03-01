using CS.Api.Facade.CustomAuthentication;
using CS.Api.Facade.Models.Dashboard;
using CS.Api.Facade.Security;
using CS.Api.Services.Module;
using System.Linq;
using System.Web.Mvc;

namespace CS.Api.Facade.Controllers
{
    [CustomAuthorize]
    public class DashboardController : Controller
    {
        private readonly IModuleService _moduleService;
        public DashboardController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MenuBar()
        {
            var roleId = SecurityContext.UserIdentity.GetRoleId();

            var modules = _moduleService.Get(roleId).Select(t => t.ToView()).ToList();

            var routeValues = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values;
            var currentAction = routeValues.ContainsKey("action") ? (string)routeValues["action"] : string.Empty;
            var currentController = routeValues.ContainsKey("controller") ? (string)routeValues["controller"] : string.Empty;

            var activeModuleIndex = modules.FindIndex(t => t.Action == currentAction && t.Controller == currentController);
            if (activeModuleIndex != -1) modules[activeModuleIndex].IsActive = true;
            return PartialView("MenuBar", modules);
        }
    }
}