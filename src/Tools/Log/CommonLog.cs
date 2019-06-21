using Serilog;

namespace TianCheng.Model
{
    /// <summary>
    /// 通用的日志记录 默认配置
    /// </summary>
    public class CommonLog
    {
        /// <summary>
        /// 日志操作对象
        /// </summary>
        static private Serilog.ILogger _Logger = null;
        /// <summary>
        /// 日志操作
        /// </summary>
        static public Serilog.ILogger Logger
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
        /// <summary>
        /// 默认的文件格式
        /// </summary>
        private static readonly string FileFormat = "Logs/TianCheng.Common-{Date}.txt";

        /// <summary>
        /// 初始化日志
        /// </summary>
        static private void InitLogger() =>
            _Logger = new LoggerConfiguration()
                        .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                        .WriteTo.Debug()
                        .WriteTo.RollingFile(FileFormat,Serilog.Events.LogEventLevel.Warning)
                        .CreateLogger();
    }
}
