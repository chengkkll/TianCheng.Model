using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TianCheng.Model
{
    /// <summary>
    /// 获取服务对象
    /// </summary>
    public static class ServiceLoader
    {
        /// <summary>
        /// 获取IServiceProvider
        /// </summary>
        public static IServiceProvider Instance { get; set; }
        /// <summary>
        /// 获取IServiceCollection
        /// </summary>
        public static IServiceCollection Services { get; set; }
        /// <summary>
        /// 获取Configuration
        /// </summary>
        public static IConfiguration Configuration { get; set; }
        /// <summary>
        /// 获取系统的环境变量
        /// </summary>
        static public IHostingEnvironment Environment
        {
            get
            {
                return GetService<IHostingEnvironment>();
            }
        }
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            return (T)Instance.GetService(typeof(T));
        }

        /// <summary>
        /// 根据类型名称获取服务
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static object GetService(string typeName)
        {
            foreach (var ser in Services)
            {
                if (typeName.Contains(ser.ServiceType.Name))
                {
                    return Instance.GetService(ser.ServiceType);
                }
            }
            return null;
        }

        /// <summary>
        /// 创建一份配置文件信息
        /// </summary>
        /// <returns></returns>
        public static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ServiceLoader.Environment.EnvironmentName}.json", optional: true)
                .Build();
        }

        /// <summary>
        /// 根据环境变量组合appsettings.json
        /// 服务器的系统环境变量中需要添加：ASPNETCORE_ENVIRONMENT=Production
        /// </summary>
        /// <param name="context"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static void Appsettings(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.json", optional: false)
                   .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();
        }
    }
}
