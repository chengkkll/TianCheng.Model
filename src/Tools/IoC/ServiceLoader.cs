using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// 获取服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            return (T)Instance.GetService(typeof(T));
        }
    }
}
