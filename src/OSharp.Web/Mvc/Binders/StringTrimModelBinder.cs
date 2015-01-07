// -----------------------------------------------------------------------
//  <copyright file="StringTrimModelBinder.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-08-04 17:37</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;


namespace OSharp.Web.Mvc.Binders
{
    /// <summary>
    /// 模型字符串处理类，处理传入字符串的前后空格
    /// </summary>
    public class StringTrimModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = base.BindModel(controllerContext, bindingContext);
            if (value is string)
            {
                return (value as string).Trim();
            }
            return value;
        }
    }
}