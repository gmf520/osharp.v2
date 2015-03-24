// -----------------------------------------------------------------------
//  <copyright file="UserConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-24 17:04</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Demo.ModelConfigurations.Identity
{
    public partial class UserConfiguration
    {
        partial void UserConfigurationAppend()
        {
            HasMany(m => m.Roles).WithMany(n => n.Users);
        }
    }
}