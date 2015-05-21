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

using OSharp.Demo.Contracts;
using OSharp.Demo.Dtos.Identity;
using OSharp.Demo.Models.Identity;
using OSharp.Utility;
using OSharp.Utility.Data;
using OSharp.Utility.Extensions;
using OSharp.Utility.Filter;
using OSharp.Web.Mvc.Binders;
using OSharp.Web.Mvc.Security;
using OSharp.Web.UI;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    public class RolesController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IIdentityContract IdentityContract { get; set; }

        #region Ajax功能

        #region 获取数据

        //id: 组织机构编号
        [AjaxOnly]
        public ActionResult GridData(int? id)
        {
            int total;
            GridRequest request = new GridRequest(Request);
            if (id.HasValue && id.Value > 0)
            {
                request.FilterGroup.Rules.Add(new FilterRule("Organization.Id", id.Value));
            }
            var datas = GetQueryData<Role, int>(IdentityContract.Roles, out total, request).Select(m => new
            {
                m.Id,
                m.Name,
                m.Remark,
                m.IsAdmin,
                m.IsLocked,
                OrganizationId = m.Organization.Id,
                OrganizationName = m.Organization.Name,
                UserCount = m.Users.Count
            });
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<RoleDto>))] ICollection<RoleDto> dtos)
        {
            dtos.CheckNotNull("dtos" );
            OperationResult result = IdentityContract.AddRoles(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<RoleDto>))] ICollection<RoleDto> dtos)
        {
            dtos.CheckNotNull("dtos" );
            OperationResult result = IdentityContract.EditRoles(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids" );
            OperationResult result = IdentityContract.DeleteRoles(ids.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion
    }
}