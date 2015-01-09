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

using OSharp.Demo.Web.ViewModels;
using OSharp.Web.Mvc.Security;


namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        public ActionResult GetMenuData()
        {
            List<TreeNode> nodes = new List<TreeNode>()
            {
                new TreeNode()
                {
                    Text = "权限",
                    IconCls = "pic_26",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "用户管理", IconCls = "pic_5", Url = Url.Action("Index", "Users") },
                        new TreeNode() { Text = "角色管理", IconCls = "pic_198", Url = Url.Action("Index", "Roles") },
                        new TreeNode() { Text = "组织机构管理", IconCls = "pic_93", Url = Url.Action("Index", "Organizations") },
                    }
                },
                new TreeNode()
                {
                    Text = "系统",
                    IconCls = "pic_100",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "操作日志", IconCls = "pic_125", Url = Url.Action("Index", "OperateLogs") },
                        new TreeNode() { Text = "系统日志", IconCls = "pic_101", Url = Url.Action("Index", "SystemLogs") },
                        new TreeNode() { Text = "系统设置", IconCls = "pic_89", Url = Url.Action("Index", "SystemSettings") }
                    }
                }
            };

            Action<ICollection<TreeNode>> action = list =>
            {
                foreach (var node in list)
                {
                    node.Id = "node" + node.Text;
                }
            };

            foreach (var node in nodes)
            {
                node.Id = "node" + node.Text;
                if (node.Children != null && node.Children.Count > 0)
                {
                    action(node.Children);
                }
            }

            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 验证数据

        #endregion

        #region 功能方法

        #endregion

        #endregion

        #region 视图功能

        #endregion


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}