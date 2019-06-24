using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 自动注册服务
    /// </summary>
    static public class ServiceRegister
    {
        /// <summary>
        /// 增加业务的Service
        /// </summary>
        /// <param name="services"></param>
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // 注册Service
            foreach (Type type in TianCheng.Model.AssemblyHelper.GetTypeByInterface<TianCheng.Model.IServiceRegister>())
            {
                if (type.GetTypeInfo().IsClass)
                    services.AddTransient(type);
            }
        }
    }
}