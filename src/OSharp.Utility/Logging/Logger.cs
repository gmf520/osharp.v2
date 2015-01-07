// -----------------------------------------------------------------------
//  <copyright file="Logger.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-08-12 18:09</last-date>
// -----------------------------------------------------------------------

using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

using OSharp.Utility.Extensions;


namespace OSharp.Utility.Logging
{
    /// <summary>
    /// 日志记录者
    /// </summary>
    public sealed class Logger : ILogger
    {
        internal Logger(Type type)
            : this(type.FullName)
        { }

        internal Logger(string name)
        {
            Name = name;
            EntryLevel = ConfigurationManager.AppSettings.Get("OSharp-EntryLogLevel").CastTo(LogLevel.Off);
        }

        /// <summary>
        /// 获取 日志记录者名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置 日志级别的入口控制，级别决定是否执行相应级别的日志记录功能
        /// </summary>
        public LogLevel EntryLevel { get; set; }

        #region Implementation of ILogger

        /// <summary>
        /// 写入<see cref="LogLevel.Trace"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Trace<T>(T message)
        {
            if (!IsEnabledFor(LogLevel.Trace))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Trace(message);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Trace"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Trace(string format, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Trace))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Trace(format, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Debug"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Debug<T>(T message)
        {
            if (!IsEnabledFor(LogLevel.Debug))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Debug(message);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Debug"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Debug(string format, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Debug))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Debug(format, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Info"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Info<T>(T message)
        {
            if (!IsEnabledFor(LogLevel.Info))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Info(message);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Info"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Info(string format, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Info))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Info(format, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Warn"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Warn<T>(T message)
        {
            if (!IsEnabledFor(LogLevel.Warn))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Warn(message);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Warn"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Warn(string format, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Warn))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Warn(format, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Error<T>(T message)
        {
            if (!IsEnabledFor(LogLevel.Error))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Error(message);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Error(string format, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Error))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Error(format, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>日志消息，并记录异常
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="exception">异常</param>
        public void Error<T>(T message, Exception exception)
        {
            if (!IsEnabledFor(LogLevel.Error))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Error(message, exception);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>格式化日志消息，并记录异常
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="exception">异常</param>
        /// <param name="args">格式化参数</param>
        public void Error(string format, Exception exception, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Error))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Error(format, exception, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Fatal<T>(T message)
        {
            if (!IsEnabledFor(LogLevel.Fatal))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Fatal(message);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Fatal(string format, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Fatal))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Fatal(format, args);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>日志消息，并记录异常
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="exception">异常</param>
        public void Fatal<T>(T message, Exception exception)
        {
            if (!IsEnabledFor(LogLevel.Fatal))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Fatal(message, exception);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>格式化日志消息，并记录异常
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="exception">异常</param>
        /// <param name="args">格式化参数</param>
        public void Fatal(string format, Exception exception, params object[] args)
        {
            if (!IsEnabledFor(LogLevel.Fatal))
            {
                return;
            }
            foreach (ILog log in LogManager.Adapters.Select(adapter => adapter.GetLogger(Name)))
            {
                log.Fatal(format, exception, args);
            }
        }

        #endregion

        #region 私有方法

        private bool IsEnabledFor(LogLevel level)
        {
            return level >= EntryLevel;
        }

        #endregion
    }
}