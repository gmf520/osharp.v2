// -----------------------------------------------------------------------
//  <copyright file="IdentityService.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-07 23:20</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OSharp.Core;
using OSharp.Core.Data;
using OSharp.Demo.Web.Models;


namespace OSharp.Demo.Web.Services.Impl
{
    /// <summary>
    /// 业务实现——账户模块
    /// </summary>
    public partial class IdentityService : ServiceBase, IIdentityContract
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Role, int> _roleRepository;
        private readonly IRepository<Organization, int> _organizationRepository;

        /// <summary>
        /// 初始化一个<see cref="IdentityService"/>类型的新实例
        /// </summary>
        public IdentityService(IRepository<User, int> userRepository,
            IRepository<Role, int> roleRepository,
            IRepository<Organization, int> organizationRepository)
            : base(userRepository.UnitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _organizationRepository = organizationRepository;
        }
    }
}