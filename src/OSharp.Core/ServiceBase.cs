// -----------------------------------------------------------------------
//  <copyright file="ServiceBase.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-07-17 3:42</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using OSharp.Core.Data;


namespace OSharp.Core
{
    /// <summary>
    /// 业务实现基类
    /// </summary>
    public abstract class ServiceBase
    {
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取或设置 单元操作对象
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; private set; }
    }
}