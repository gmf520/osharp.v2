using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;

using OSharp.Utility.Logging;


namespace OSharp.Demo.Web.Logging
{
    /// <summary>
    /// log4net 日志输出适配器
    /// </summary>
    public class Log4NetLoggerAdapter : LoggerAdapterBase
    {
        /// <summary>
        /// 初始化一个<see cref="Log4NetLoggerAdapter"/>类型的新实例
        /// </summary>
        public Log4NetLoggerAdapter()
        {
            RollingFileAppender appender = new RollingFileAppender
            {
                Name = "root",
                File = "logs\\log_",
                AppendToFile = true,
                LockingModel = new FileAppender.MinimalLock(),
                RollingStyle = RollingFileAppender.RollingMode.Date,
                DatePattern = "yyyyMMdd-HH\".log\"",
                StaticLogFileName = false,
                Threshold = Level.Debug,
                MaxSizeRollBackups = 10,
                Layout = new PatternLayout("%n[%d{yyyy-MM-dd HH:mm:ss.fff}] %-5p %c %t %w %n%m%n")
            };
            appender.ClearFilters();
            appender.AddFilter(new LevelMatchFilter { LevelToMatch = Level.Info });
            BasicConfigurator.Configure(appender);
            appender.ActivateOptions();
        }


        #region Overrides of LoggerAdapterBase

        /// <summary>
        /// 创建指定名称的缓存实例
        /// </summary>
        /// <param name="name">指定名称</param>
        /// <returns></returns>
        protected override ILog CreateLogger(string name)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(name);
            return new Log4NetLog(log);
        }

        #endregion
    }
}