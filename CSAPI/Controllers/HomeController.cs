using CS.Api.Services.Authentication;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web;
using System.Security.Claims;
using static CS.Api.Facade.Models.Home.Home;

namespace CS.Api.Facade.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public HomeController(ITokenService tokenService,
            IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        // GET: Home
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.Authenticate(model.UserName, model.Password);
                if (userId != null)
                {
                    var user = _userService.GetById(userId);
                    var c = user.UserId;
                    if (user != null)
                    {
                        CustomSerializeModel userModel = new CustomSerializeModel()
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            RoleId = user.RoleId,
                            RoleName = user.RoleName
                        };

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        var userIdentity = (ClaimsIdentity)System.Web.HttpContext.Current.User.Identity;
                        userIdentity.AddClaim(new Claim("roleid", user.RoleId.ToString()));

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("cs_cookie", enTicket);
                        Response.Cookies.Add(faCookie);
                    }
                    return RedirectToAction("Dashboard", "Dashboard");
                }
            }
            ModelState.AddModelError("", "Username or Password invalid.");
            return View(model);
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("cs_cookie", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home", null);
        }

        //public ActionResult Menu()
        //{
        //    var routeValues = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values;
        //    var currentAction = routeValues.ContainsKey("action") ? (string)routeValues["action"] : string.Empty;
        //    var currentController = routeValues.ContainsKey("controller") ? (string)routeValues["controller"] : string.Empty;

        //    var modules = new List<Module>();
        //    Module m1 = new Module()
        //    {
        //        ModuleId = 1,
        //        Title = "Administration",
        //        Class = "fa fa-user-o"
        //    };

        //    Module m2 = new Module()
        //    {
        //        ModuleId = 2,
        //        Title = "User",
        //        Action = "Get",
        //        Controller = "User",
        //        Class = "fa fa-circle-o",
        //        ParentModuleId = 1
        //    };

        //    Module m3 = new Module()
        //    {
        //        ModuleId = 3,
        //        Title = "RoleModulePermission",
        //        Action = "Get",
        //        Controller = "RoleModulePermissions",
        //        Class = "fa fa-circle-o",
        //        ParentModuleId = 1
        //    };

        //    Module m4 = new Module()
        //    {
        //        ModuleId = 4,
        //        Title = "Inventory",
        //        Class = "fa fa-wrench"
        //    };

        //    Module m5 = new Module()
        //    {
        //        ModuleId = 3,
        //        Title = "Stock",
        //        Action = "Get",
        //        Controller = "Stock",
        //        Class = "fa fa-circle-o",
        //        ParentModuleId = 4
        //    };

        //    Module m6 = new Module()
        //    {
        //        ModuleId = 4,
        //        Title = "Visit us",
        //        Class = "fa fa-circle-o",
        //    };

        //    modules.Add(m1);
        //    modules.Add(m2);
        //    modules.Add(m3);
        //    modules.Add(m4);
        //    modules.Add(m5);
        //    modules.Add(m6);

        //    var activeModuleIndex = modules.FindIndex(t => t.Action == currentAction && t.Controller == currentController);
        //    if (activeModuleIndex != -1) modules[activeModuleIndex].IsActive = true;

        //    return PartialView("MenuBar", modules);
        //}
    }

    //public class Module
    //{
    //    public int ModuleId { get; set; }
    //    public string Title { get; set; }
    //    public string Action { get; set; }
    //    public string Controller { get; set; }
    //    public string Class { get; set; }
    //    public bool IsActive { get; set; }
    //    public Nullable<int> ParentModuleId { get; set; }
    //}
}