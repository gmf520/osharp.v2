// -----------------------------------------------------------------------
//  <copyright file="HomeController.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2015-01-09 13:50</last-date>
// -----------------------------------------------------------------------

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
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }


    public class TestFilterAttribute : AuthorizeAttribute
    {
        public IIdentityContract IdentityContract { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool flag = IdentityContract == null;
        }
    }
}