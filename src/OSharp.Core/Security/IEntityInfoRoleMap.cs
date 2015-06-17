// -----------------------------------------------------------------------
//  <copyright file="IEntityInfoRoleMap.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-17 0:19</last-date>
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
    /// 实体数据角色映射接口
    /// </summary>
    public interface IEntityInfoRoleMap<out TKey, out TEntityInfoKey, out TRoleKey>
    {
        /// <summary>
        /// 获取 实体数据角色映射编号
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// 获取 相关实体信息
        /// </summary>
        IEntityInfo<TEntityInfoKey> EntityInfo { get; }

        /// <summary>
        /// 获取 相关角色
        /// </summary>
        IRole<TRoleKey> Role { get; }
    }
}