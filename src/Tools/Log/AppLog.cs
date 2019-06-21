using Serilog;

namespace TianCheng.Model.Tools.Log
{
    /// <summary>
    /// 读取配置信息的日志
    /// </summary>
    public class AppLog
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
        private static readonly string FileFormat = "Logs/app-{Date}.txt";

        /// <summary>
        /// 初始化日志
        /// </summary>
        static private void InitLogger()
        {
            try
            {
                var con = new LoggerConfiguration().ReadFrom.Configuration(ServiceLoader.Configuration);
                _Logger = con.CreateLogger();
            }
            catch
            {
                _Logger = new LoggerConfiguration()
                            .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                            .WriteTo.Debug()
                            .WriteTo.RollingFile(FileFormat)
                            .CreateLogger();
            }
        }
    }
}
