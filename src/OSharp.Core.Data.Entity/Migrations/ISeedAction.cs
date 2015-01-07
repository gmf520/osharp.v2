using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Core.Data.Entity.Migrations
{
    /// <summary>
    /// 数据迁移初始化种子数据操作基类
    /// </summary>
    public interface ISeedAction
    {
        /// <summary>
        /// 获取 操作排序，数值越小越先执行
        /// </summary>
        int Order { get; }

        /// <summary>
        /// 定义种子数据初始化过程
        /// </summary>
        /// <param name="context">数据上下文</param>
        void Action(DbContext context);
    }
}
