// -----------------------------------------------------------------------
//  <copyright file="Role.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-08 0:24</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OSharp.Core.Data;


namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——角色信息
    /// </summary>
    public class Role : EntityBase<int>
    {
        /// <summary>
        /// 初始化一个<see cref="Role"/>类型的新实例
        /// </summary>
        public Role()
        {
            Users = new List<User>();
        }

        /// <summary>
        /// 获取或设置 角色名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 角色备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 获取或设置 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 获取或设置 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 获取或设置 角色所属组织机构
        /// </summary>
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// 获取或设置 拥有此角色的用户集合
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}