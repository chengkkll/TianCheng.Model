using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TianCheng.Model;

namespace WebApi.Controllers
{
    [Route("api/setting")]
    public class ConfigurationDemoController
    {
        IConfiguration _Configuration;
        IHostingEnvironment _env;

        public ConfigurationDemoController(IConfiguration configuration, IHostingEnvironment env)
        {
            _Configuration = configuration;
            _env = env;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("config")]
        public string ByConfiguration()
        {
            // 两种直接从文件中取值得形式

            var node = _Configuration.GetSection("DatabaseInfo");

            DatabaseInfo di = new DatabaseInfo()
            {
                Database = node["Database"],
                ServerAddress = _Configuration.GetSection("DatabaseInfo:ServerAddress").Value
            };
            return di.ToJson();
        }

        [HttpGet("object")]
        public string GetObject()
        {
            // 取出的值直接转成对象
            var node = _Configuration.GetSection("DatabaseInfo");
            DatabaseInfo di = node.Get<DatabaseInfo>();

            return di.ToJson();
        }

        [HttpGet("test")]
        public string Test()
        {

            foreach (Type type in TianCheng.Model.AssemblyHelper
               .GetTypeByInterfaceName("TianCheng.BaseService.IServiceRegister"))
            {
                if (type.GetTypeInfo().IsClass)
                {
                    //services.AddTransient(type);
                }
            }


            var node = _Configuration.GetSection("DBConnection");

            DatabaseInfo di = new DatabaseInfo();
            if (_env.IsDevelopment())
            {
                var first = node.GetChildren().FirstOrDefault();
                if (first != null)
                {
                    di = first.Get<DatabaseInfo>();
                }
            }
            else
            {
                var n = _Configuration.GetSection("DBConnection:Release");
                di = n.Get<DatabaseInfo>();
            }



            return di.ToJson();
        }

        /// <summary>
        /// 从自定义的JSON文件中读取
        /// </summary>
        /// <returns></returns>
        [HttpGet("MyConfig")]
        public string MyJson()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("config.json").AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            var node = configuration.GetSection("ConfigDatabaseInfo");
            DatabaseInfo di = new DatabaseInfo()
            {
                Database = node["Database"],
                ServerAddress = node["ServerAddress"]
            };
            return di.ToJson();
        }

    }
}
