// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:07:04 18:01</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSharp.Utility.Filter
{
    /// <summary>
    /// 筛选条件
    /// </summary>
    public class FilterRule
    {
        #region 构造函数

        /// <summary>
        /// 初始化一个<see cref="FilterRule"/>的新实例
        /// </summary>
        public FilterRule()
        {
            Operate = FilterOperate.Equal;
        }

        /// <summary>
        /// 使用指定数据名称，数据值初始化一个<see cref="FilterRule"/>的新实例
        /// </summary>
        /// <param name="field">数据名称</param>
        /// <param name="value">数据值</param>
        public FilterRule(string field, object value)
            : this()
        {
            Field = field;
            Value = value;
        }

        /// <summary>
        /// 使用指定数据名称，数据值及操作方式初始化一个<see cref="FilterRule"/>的新实例
        /// </summary>
        /// <param name="field">数据名称</param>
        /// <param name="value">数据值</param>
        /// <param name="operate">操作方式</param>
        public FilterRule(string field, object value, FilterOperate operate)
            : this(field, value)
        {
            Operate = operate;
        }

        /// <summary>
        /// 初始化一个<see cref="FilterRule"/>类型的新实例
        /// </summary>
        /// <param name="field">数据名称</param>
        /// <param name="value">数据值</param>
        /// <param name="operateCode">操作方式的前台码</param>
        public FilterRule(string field, object value, string operateCode)
            : this(field, value, FilterHelper.GetFilterOperate(operateCode))
        { }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置 属性名称
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 获取或设置 属性值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 获取或设置 操作类型
        /// </summary>
        public FilterOperate Operate { get; set; }

        #endregion
    }
}