using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

using OSharp.Core.Data.Entity.Migrations;
using OSharp.Demo.Web.Models;


namespace OSharp.Demo.Web.Services.Impl
{
    public class IdentitySeedAction : ISeedAction
    {
        /// <summary>
        /// 获取 操作排序，数值越小越先执行
        /// </summary>
        public int Order { get { return 0; } }

        /// <summary>
        /// 定义种子数据初始化过程
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void Action(DbContext context)
        {
            List<Organization> organizations = new List<Organization>()
            {
                new Organization(){Name = "系统", Remark = "系统根节点", },
            };
            context.Set<Organization>().AddOrUpdate(m => new { m.Name }, organizations.ToArray());
        }
    }
}