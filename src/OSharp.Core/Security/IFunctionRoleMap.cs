// -----------------------------------------------------------------------
//  <copyright file="IFunctionRoleMap.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-17 0:16</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSharp.Core.Identity;


namespace OSharp.Core.Security
{
    /// <summary>
    /// 功能角色映射接口
    /// </summary>
    public interface IFunctionRoleMap<out TKey, out TFunctionKey, out TRoleKey>
    {
        /// <summary>
        /// 获取 功能角色映射编号
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// 获取 相关功能信息
        /// </summary>
        IFunction<TFunctionKey> Function { get; }

        /// <summary>
        /// 获取 相关角色信息
        /// </summary>
        IRole<TRoleKey> Role { get; }

        /// <summary>
        /// 获取 访问类型
        /// </summary>
        VisiteType VisiteType { get; }
    }
}