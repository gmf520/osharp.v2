// -----------------------------------------------------------------------
//  <copyright file="GridData.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-07-22 21:45</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;


namespace OSharp.Web.UI
{
    /// <summary>
    /// 列表数据，封装列表的行数据与总记录数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GridData<T>
    {
        public GridData()
            : this(new List<T>(), 0)
        { }

        public GridData(IEnumerable<T> rows, int total)
        {
            Rows = rows;
            Total = total;
        }

        /// <summary>
        /// 获取或设置 行数据
        /// </summary>
        public IEnumerable<T> Rows { get; set; }

        /// <summary>
        /// 获取或设置 数据行数
        /// </summary>
        public int Total { get; set; }
    }
}