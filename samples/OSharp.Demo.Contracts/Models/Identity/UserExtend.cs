// -----------------------------------------------------------------------
//  <copyright file="UserExtend.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-08 0:20</last-date>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using OSharp.Core.Data;


namespace OSharp.Demo.Models.Identity
{
    /// <summary>
    /// 实体类——用户扩展信息
    /// </summary>
    public class UserExtend : EntityBase<int>
    {
        /// <summary>
        /// 注册IP地址
        /// </summary>
        [StringLength(15)]
        public string RegistedIp { get; set; }

        public virtual User User { get; set; }
    }
}