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

using OSharp.Utility.Extensions;
using OSharp.Utility.Logging;


namespace OSharp.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            Logger.Debug("访问首页，将转向到后台管理首页");
            return RedirectToAction("Index", "Home", new { area = "Admin" });
            //var data = new
            //{
            //    OrganizationCount = _identityContract.Organizations.Count(),
            //    UserCount = _identityContract.Users.Count(),
            //    RoleCount = _identityContract.Roles.Count()
            //};
            //ViewBag.Data = data.ToDynamic();
            //return View();
        }
    }
}