using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;

namespace TianCheng.Model
{
    /// <summary>
    /// 通用的日志记录
    /// </summary>
    public class CommonLog
    {
        static private ILogger _Logger = null;

        static private LogLevel DebugLevel = LogLevel.Information;
        static private LogLevel ConsoleLevel = LogLevel.Warning;
        static private LogLevel FileLevel = LogLevel.Warning;
        static private string FileFormat = "Logs/TianCheng.Common-{Date}.txt";
        static private string CategoryName = "Common";
        /// <summary>
        /// 初始化日志
        /// </summary>
        static private void InitLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();

            loggerFactory.AddConsole(ConsoleLevel);         // 在控制台输出
            loggerFactory.AddDebug(DebugLevel);             // 在VS输出窗口输出
            loggerFactory.AddFile(FileFormat, FileLevel);   // 在文件中输出

            _Logger = loggerFactory.CreateLogger(CategoryName);
        }
        

        /// <summary>
        /// 日志操作
        /// </summary>
        static public ILogger Logger
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
