using Microsoft.AspNetCore.Mvc;
using Serilog;
using TianCheng.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController
    {
        static private Serilog.ILogger _Logger = null;
        /// <summary>
        ///  获取网站所在的磁盘路径
        /// </summary>
        [HttpGet("RootPath")]
        public ResultView RootPath()
        {
            return ResultView.Success(ServiceLoader.Environment.ContentRootPath);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        [HttpPost("SendEmail")]
        public ResultView SendEmail()
        {
            QueryInfo query = new QueryInfo();
            string json = query.ToJson();
            QueryInfo info = json.JsonToObject<QueryInfo>();

            if (_Logger == null)
            {
                _Logger = new Serilog.LoggerConfiguration()
                    .WriteTo.Email(
                        fromEmail: "tianchengok2019@163.com",
                        toEmail: "17814198@qq.com",
                        mailServer: "smtp.163.com",
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning,
                        networkCredential: new System.Net.NetworkCredential("tianchengok2019@163.com", "1234qwer"),
                        outputTemplate: "[{Level}] {Message}{NewLine}{Exception}",
                        mailSubject: "系统错误-提醒邮件")
                    .CreateLogger();
            }
            _Logger.Fatal("测试邮件 {test}", "邮件发送内容");
            return ResultView.Success();

            
        }
    }
}
