// -----------------------------------------------------------------------
//  <copyright file="Member.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-07 23:33</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OSharp.Core.Data;


namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——用户信息
    /// </summary>
    public class User : EntityBase<int>
    {
        /// <summary>
        /// 初始化一个<see cref="User"/>类型的新实例
        /// </summary>
        public User()
        {
            Roles = new List<Role>();
        }

        /// <summary>
        /// 获取 唯一用户名
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 密码
        /// </summary>
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置 电子邮箱
        /// </summary>
        [Required, StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [StringLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 获取或设置 用户扩展信息
        /// </summary>
        public virtual UserExtend Extend { get; set; }

        /// <summary>
        /// 获取或设置 用户角色集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
    }
}