using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OSharp.Core.Data.Entity;


namespace OSharp.Demo.Web.Models.EntityConfigurations
{
    public class UserConfiguration : EntityConfigurationBase<User, int>
    {
        public UserConfiguration()
        {
            HasMany(m => m.Roles).WithMany(n => n.Users);
        }
    }
}