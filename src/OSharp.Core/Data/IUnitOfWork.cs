// -----------------------------------------------------------------------
//  <copyright file="IUnitOfWork.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-07-17 3:36</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Core.Data
{
    /// <summary>
    /// 业务单元操作接口
    /// </summary>
    public interface IUnitOfWork : IDependency
    {
        #region 属性

        /// <summary>
        /// 获取或设置 是否开启事务提交
        /// </summary>
        bool TransactionEnabled { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 提交当前单元操作的更改。
        /// </summary>
        /// <returns>操作影响的行数</returns>
        int SaveChanges();

#if NET45

        /// <summary>
        /// 异步提交当前单元操作的更改。
        /// </summary>
        /// <returns>操作影响的行数</returns>
        Task<int> SaveChangesAsync();

#endif

        #endregion
    }
}