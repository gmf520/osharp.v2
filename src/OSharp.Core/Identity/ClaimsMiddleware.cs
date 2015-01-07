// -----------------------------------------------------------------------
//  <copyright file="ClaimsMiddleware.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-12-14 4:28</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin;


namespace OSharp.Core.Identity
{
    /// <summary>
    /// 声明式权限中间件
    /// </summary>
    public class ClaimsMiddleware : OwinMiddleware
    {
        /// <summary>
        /// Instantiates the middleware with an optional pointer to the next component.
        /// </summary>
        /// <param name="next"/>
        public ClaimsMiddleware(OwinMiddleware next)
            : base(next)
        { }

        #region Overrides of OwinMiddleware

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context"/>
        /// <returns/>
        public override Task Invoke(IOwinContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}