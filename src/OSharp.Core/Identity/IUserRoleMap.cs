// -----------------------------------------------------------------------
//  <copyright file="IUserRoleMap.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-16 22:08</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Core.Identity
{
    /// <summary>
    /// 用户角色映射接口
    /// </summary>
    public interface IUserRoleMap<out TKey, out TUserKey, out TRoleKey>
    {
        /// <summary>
        /// 获取 用户角色映射编号
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// 获取 相关用户信息
        /// </summary>
        IUser<TUserKey> User { get; }

        /// <summary>
        /// 获取 相关角色信息
        /// </summary>
        IRole<TRoleKey> Role { get; }
    }
}