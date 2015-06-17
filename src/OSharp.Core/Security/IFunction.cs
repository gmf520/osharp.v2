// -----------------------------------------------------------------------
//  <copyright file="IFunction.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-06-16 22:10</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Core.Security
{
    /// <summary>
    /// 功能接口，最小功能信息
    /// </summary>
    public interface IFunction<out TKey>
    {
        /// <summary>
        /// 获取 功能编号
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// 获取 功能名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取 功能地址
        /// </summary>
        string Url { get; }

        /// <summary>
        /// 获取 功能类型
        /// </summary>
        FunctionType FunctionType { get; }
    }
}