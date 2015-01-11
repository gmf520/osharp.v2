// -----------------------------------------------------------------------
//  <copyright file="RolesController.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2015-01-09 20:43</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSharp.Demo.Web.Dtos;
using OSharp.Utility.Extensions;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        public ActionResult GridData()
        {
            List<object> data = new List<object>();
            for (int i = 1; i <= 5; i++)
            {
                var item = new { Id = i, Name = "角色" + i, Remark = "角色描述" + i, CreatedTime = DateTime.Now.AddMinutes(i) };
                data.Add(item);
            }
            return Json(new GridData<object>(data, data.Count), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 验证数据

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<RoleDto>))] ICollection<RoleDto> dtos)
        {
            string[] names = dtos.Select(m => m.Name).ToArray();
            AjaxResult result = new AjaxResult("角色“{0}”新增成功".FormatWith(names.ExpandAndToString()), AjaxResultType.Success);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<RoleDto>))] ICollection<RoleDto> dtos)
        {
            string[] names = dtos.Select(m => m.Name).ToArray();
            AjaxResult result = new AjaxResult("角色“{0}”新增成功".FormatWith(names.ExpandAndToString()), AjaxResultType.Success);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            AjaxResult result = new AjaxResult("{0} 个角色删除成功".FormatWith(ids.Count), AjaxResultType.Success);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

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