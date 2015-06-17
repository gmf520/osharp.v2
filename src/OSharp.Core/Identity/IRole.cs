// -----------------------------------------------------------------------
//  <copyright file="IRole.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-16 22:03</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Core.Identity
{
    /// <summary>
    /// 角色接口，最小化角色信息
    /// </summary>
    public interface IRole<out TKey>
    {
        /// <summary>
        /// 获取 角色编号
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// 获取 角色名称
        /// </summary>
        string Name { get; }
    }
}