// -----------------------------------------------------------------------
//  <copyright file="OSharpContext.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-08-12 18:16</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;


namespace OSharp.Core.Context
{
    /// <summary>
    /// OSharp框架上下文，用于构造OSharp框架运行环境
    /// </summary>
    [Serializable]
    public class OSharpContext : Dictionary<string, object>
    {
        private const string CallContextKey = "__OSharp_CallContext";
        private const string OperatorKey = "__OSharp_Context_Operator";
        private static readonly Lazy<OSharpContext> ContextLazy = new Lazy<OSharpContext>(() => new OSharpContext());

        /// <summary>
        /// 初始化一个<see cref="OSharpContext"/>类型的新实例
        /// </summary>
        public OSharpContext()
        { }

        /// <summary>
        /// 初始化一个<see cref="OSharpContext"/>类型的新实例
        /// </summary>
        protected OSharpContext(SerializationInfo info, StreamingContext context)
            :base(info, context)
        { }

        /// <summary>
        /// 获取或设置 当前上下文
        /// </summary>
        public static OSharpContext Current
        {
            get
            {
                OSharpContext context = CallContext.LogicalGetData(CallContextKey) as OSharpContext;
                if (context != null)
                {
                    return context;
                }
                context = ContextLazy.Value;
                CallContext.LogicalSetData(CallContextKey, context);
                return context;
            }
            set
            {
                if (value == null)
                {
                    CallContext.FreeNamedDataSlot(CallContextKey);
                    return;
                }
                CallContext.LogicalSetData(CallContextKey, value);
            }
        }

        /// <summary>
        /// 获取 当前操作者
        /// </summary>
        public Operator Operator
        {
            get
            {
                if (!ContainsKey(OperatorKey))
                {
                    this[OperatorKey] = new Operator();
                }
                return this[OperatorKey] as Operator;
            }
        }
    }
}