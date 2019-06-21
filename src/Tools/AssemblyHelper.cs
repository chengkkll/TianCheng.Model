using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TianCheng.Model
{
    /// <summary>
    /// 程序集处理
    /// </summary>
    public class AssemblyHelper
    {
        /// <summary>
        /// 获取当前目录下有效的程序集
        /// </summary>
        /// <returns></returns>
        static public List<Assembly> GetAssemblyList()
        {
            List<Assembly> assemblyList = new List<Assembly>();

            foreach (var library in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.FullName));
                    if (assembly.FullName.StartsWith("Microsoft") || assembly.FullName.StartsWith("System") || assembly.FullName.StartsWith("MongoDB") ||
                        assembly.FullName.StartsWith("Interop") || assembly.FullName.StartsWith("Internal") || assembly.FullName.StartsWith("Roslyn") ||
                        assembly.FullName.StartsWith("DnsClient") || assembly.FullName.StartsWith("MS.") || assembly.FullName.StartsWith("<") ||
                        assembly.FullName.StartsWith("Scrutor") || assembly.FullName.StartsWith("mscorlib") || assembly.FullName.StartsWith("netstandard") ||
                        assembly.FullName.StartsWith("OfficeOpenXml") || assembly.FullName.StartsWith("Serilog") || assembly.FullName.StartsWith("EPPlus") ||
                        assembly.FullName.StartsWith("Newtonsoft") || assembly.FullName.StartsWith("AutoMapper") || assembly.FullName.StartsWith("Swashbuckle"))
                    {
                        continue;
                    }
                    if (assembly != null)
                        assemblyList.Add(assembly);
                }
                catch
                {
                    //程序集无法反射时跳过
                }
            }

            //返回有效的程序集
            return assemblyList;
        }

        /// <summary>
        /// 反射指定类型
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        static public Type GetTypeByName(string assemblyName, string typeName)
        {
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            return assembly.GetType(typeName, true, true);
        }

        /// <summary>
        /// 根据接口名称获取所有派生类的对象类型
        /// </summary>
        /// <param name="interfaceName">接口名</param>
        /// <returns></returns>
        static public IEnumerable<Type> GetTypeByInterfaceName(string interfaceName)
        {
            IList<Type> result = new List<Type>();
            foreach (var assembly in GetAssemblyList())
            {
                foreach (var type in assembly.GetTypes())
                {
                    try
                    {
                        if (type.GetInterfaces().Where(i => i.ToString().Contains(interfaceName)).Count() > 0)  // i.FullName 会有为空的情况
                        {
                            result.Add(type);
                        }
                    }
                    catch (Exception ex)
                    {
                        CommonLog.Logger.Error(ex, $"根据接口名称获取对象类型时出错。程序集：{assembly.FullName}\r\n类型:{type.Name}");
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 根据接口类型获取所有派生类的对象类型
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <returns></returns>
        static public IEnumerable<Type> GetTypeByInterface<I>()
        {
            return GetTypeByInterfaceName(typeof(I).Name);
        }

        /// <summary>
        /// 根据接口类型获取所有派生类的对象实例
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <returns></returns>
        static public IEnumerable<I> GetInstanceByInterface<I>()
        {
            string interfaceName = typeof(I).Name;
            foreach (var assembly in GetAssemblyList())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (!type.IsClass)
                    {
                        continue;
                    }
                    if (type.GetInterfaces().Where(i => i.Name == interfaceName).Count() > 0)
                    {
                        // Todo : 如果构造函数需要参数，需要增加处理逻辑
                        object inst = assembly.CreateInstance(type.FullName);
                        yield return (I)inst;
                    }
                }
            }
        }

        /// <summary>
        /// 根据基类名称获取所有派生类的对象类型
        /// </summary>
        /// <param name="baseName">基类名</param>
        /// <returns></returns>
        static public IEnumerable<Type> GetTypeByBaseClassName(string baseName)
        {
            foreach (var assembly in GetAssemblyList())
            {
                foreach (var type in assembly.GetTypes())
                {
                    TypeInfo typeInfo = type.GetTypeInfo();
                    if (typeInfo != null && typeInfo.BaseType != null && !string.IsNullOrEmpty(typeInfo.BaseType.Name) &&
                        typeInfo.BaseType.Name.Contains(baseName))
                    {
                        yield return type;
                    }
                }
            }
        }

        /// <summary>
        /// 获取在类中拥有指定特性的特性信息列表
        /// </summary>
        /// <typeparam name="T">指定特性类型</typeparam>
        /// <returns></returns>
        static public IEnumerable<T> GetClassAttribute<T>() where T : Attribute
        {
            foreach (var assembly in GetAssemblyList())
            {
                foreach (var type in assembly.GetTypes())
                {
                    TypeInfo ti = type.GetTypeInfo();
                    T attribute = ti.GetCustomAttribute<T>(false);    //false 不获取基类中的特性
                    if (attribute != null)
                    {
                        yield return attribute;
                    }
                }
            }
        }

        /// <summary>
        /// 获取在方法中拥有指定特性的特性信息列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static public IEnumerable<T> GetMethodAttribute<T>() where T : Attribute
        {
            foreach (var assembly in GetAssemblyList())
            {
                foreach (var type in assembly.GetTypes())
                {
                    foreach (var method in type.GetMethods())
                    {
                        T attribute = method.GetCustomAttribute<T>(false);
                        if (attribute != null)
                        {
                            yield return attribute;
                        }
                    }
                }
            }
        }
    }
}
