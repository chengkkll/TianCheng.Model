using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    public class AppConfig
    {
        /// <summary>
        /// 获取系统的环境变量
        /// </summary>
        static public IHostingEnvironment Environment
        {
            get
            {
                return ServiceLoader.GetService<IHostingEnvironment>();
            }
        }

        /// <summary>
        /// IServiceProvider
        /// </summary>
        static public IConfiguration Configuration
        {
            get
            {
                return ServiceLoader.GetService<IConfiguration>();
            }
        }
    }
}
