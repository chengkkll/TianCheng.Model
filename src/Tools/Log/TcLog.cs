using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// 通用日志处理
    /// </summary>
    public class CommonLog
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        static private Logger _Logger = null;

        /// <summary>
        /// 初始化日志
        /// </summary>
        static private void InitLogger()
        {
            // 创建配置信息
            NLog.Config.LoggingConfiguration config = new NLog.Config.LoggingConfiguration();
            // 添加记录日志的媒体信息
            var fileTarget = new NLog.Targets.FileTarget
            {
                Name = "file-tc-common-log",
                FileName = "logs\\tc-common-${shortdate}.log",
                Layout = "${longdate}|${event-properties:item=EventId.Id}|${uppercase:${level}}|${logger}|${message} ${exception}"
            };
            var consoleTarget = new NLog.Targets.ConsoleTarget
            {
                Name = "console-tc-common-log",
                Layout = "${longdate}|${event-properties:item=EventId.Id}|${uppercase:${level}}|${logger}|${message} ${exception}"
            };
            config.AddTarget(fileTarget);
            config.AddTarget(consoleTarget);

            // 设置记录规则
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget, "TianCheng.CommonLog", false);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget, "TianCheng.CommonLog", true);

            // 创建日志
            _Logger = NLog.Web.NLogBuilder.ConfigureNLog(config).GetLogger("TianCheng.CommonLog");
            _Logger.Trace("init TianCheng Logger");
        }

        /// <summary>
        /// 日志操作
        /// </summary>
        static public Logger Logger
        {
            get
            {
                if (_Logger == null)
                {
                    InitLogger();
                }
                return _Logger;
            }
        }
    }
}
