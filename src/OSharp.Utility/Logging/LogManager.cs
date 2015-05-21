// -----------------------------------------------------------------------
//  <copyright file="LogManager.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-22 20:33</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;


namespace OSharp.Utility.Logging
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    public static class LogManager
    {
        private static readonly ConcurrentDictionary<string, ILogger> Loggers;
        private static readonly object LockObj = new object();

        static LogManager()
        {
            Loggers = new ConcurrentDictionary<string, ILogger>();
            Adapters = new List<ILoggerAdapter>();
        }

        /// <summary>
        /// 获取 日志适配器集合
        /// </summary>
        internal static ICollection<ILoggerAdapter> Adapters { get; private set; }

        /// <summary>
        /// 添加日志适配器
        /// </summary>
        public static void AddLoggerAdapter(ILoggerAdapter adapter)
        {
            lock (LockObj)
            {
                if (Adapters.Any(m => m == adapter))
                {
                    return;
                }
                Adapters.Add(adapter);
            }
        }

        /// <summary>
        /// 移除日志适配器
        /// </summary>
        public static void RemoveLoggerAdapter(ILoggerAdapter adapter)
        {
            lock (LockObj)
            {
                if (Adapters.All(m => m != adapter))
                {
                    return;
                }
                Adapters.Remove(adapter);
            }
        }

        /// <summary>
        /// 获取日志记录者实例
        /// </summary>
        public static ILogger GetLogger(string name)
        {
            name.CheckNotNullOrEmpty("name");
            ILogger logger;
            if (Loggers.TryGetValue(name, out logger))
            {
                return logger;
            }
            logger = new Logger(name);
            Loggers[name] = logger;
            return logger;
        }

        /// <summary>
        /// 获取指定类型的日志记录实例
        /// </summary>
        public static ILogger GetLogger(Type type)
        {
            type.CheckNotNull("type");
            return GetLogger(type.FullName);
        }
    }
}