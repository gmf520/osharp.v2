using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OSharp.Core.Data.Entity;


namespace OSharp.Demo.Web.Models.EntityConfigurations
{
    public class RoleConfiguration : EntityConfigurationBase<Role, int>
    {
        public RoleConfiguration()
        {
            HasRequired(m => m.Organization).WithMany(n => n.Roles);
        }
    }
}