// -----------------------------------------------------------------------
//  <copyright file="UsersController.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2015-01-09 20:30</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        public ActionResult GridData()
        {
            List<object> data = new List<object>();
            for (int i = 1; i <= 20; i++)
            {
                var item = new { Id = i, Name = "UserName" + i, NickName = "用户" + i, IsDeleted = false, CreatedTime = DateTime.Now.AddMinutes(i) };
                data.Add(item);
            }
            return Json(new GridData<object>(data, data.Count), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 验证数据

        #endregion

        #region 功能方法

        #endregion

        #endregion

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}