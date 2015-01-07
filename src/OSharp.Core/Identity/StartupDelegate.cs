using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Owin;


namespace OSharp.Core.Identity
{
    public class StartupDelegate
    {
        public static Action<IAppBuilder> AuthorizeAction { get; set; }
    }
}
