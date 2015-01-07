// -----------------------------------------------------------------------
//  <copyright file="IRole.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-08-17 15:12</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Core.Identity
{
    /// <summary>
    /// 最小角色信息接口
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IRole<out TKey>
    {
        /// <summary>
        /// 获取 角色主键
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// 获取 角色名称
        /// </summary>
        string Name { get; }
    }
}