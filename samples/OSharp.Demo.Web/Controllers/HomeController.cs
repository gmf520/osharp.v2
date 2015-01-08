using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSharp.Demo.Web.Models;
using OSharp.Demo.Web.Services;
using OSharp.Utility.Extensions;


namespace OSharp.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityContract _identityContract;

        public HomeController(IIdentityContract identityContract)
        {
            _identityContract = identityContract;
        }

        public ActionResult Index()
        {
            ViewBag.Data = new
            {
                OrganizationCount = _identityContract.Organizations.Count(),
                UserCount = _identityContract.Users.Count(),
                RoleCount = _identityContract.Roles.Count()
            }.ToDynamic();
            return View();
        }
	}
}