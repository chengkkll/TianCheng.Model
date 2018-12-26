﻿using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TianCheng.Model
{
    /// <summary>
    /// 程序集处理
    /// </summary>
    public class AssemblyHelper
    {
        /// <summary>
        /// 获取当前目录下有效的程序集 包含子目录
        /// </summary>
        /// <returns></returns>
        static public List<Assembly> GetAssemblyList()
        {
            List<Assembly> assemblyList = new List<Assembly>();
            ////1、获取运行目录下的所有程序集         本意想拷贝到服务器上一个库文件可以自动加载运行。现在考虑意义不太大。有时间细细调整
            ////获取根目录            
            //string runPath = AppContext.BaseDirectory;
            ////获取可能是程序集的文件列表
            //string[] fileArray = System.IO.Directory.GetFiles(runPath, "*.dll", System.IO.SearchOption.AllDirectories);
            ////获取程序集名称
            //IEnumerable<string> fileList = fileArray.Select(e => System.IO.Path.GetFileNameWithoutExtension(e));

            ////获取有效的程序集 (程序集名称和文件名相同)            
            //foreach (string file in fileList)
            //{
            //    AssemblyName an = new AssemblyName(file);
            //    if (an != null)
            //    {
            //        try
            //        {
            //            Assembly assembly = Assembly.Load(an);
            //            if (assembly != null)
            //                assemblyList.Add(assembly);
            //        }
            //        catch
            //        {
            //            //程序集无法反射时跳过
            //        }
            //    }
            //}

            //2、获取引用的再NuGet下的程序集
            foreach (CompilationLibrary library in DependencyContext.Default.CompileLibraries)
            {
                if (!library.Name.Contains("TianCheng"))
                {
                    if (library.Serviceable) continue;
                    if (library.Type == "package") continue;
                }

                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
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
        /// 根据接口名称获取所有派生类的对象类型  【在当前运行目录(包含子目录)下的所有程序集中查找】
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
                        if (type.GetInterfaces().Where(i => i.ToString().Contains(interfaceName)).Count() > 0)
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
        /// 根据接口类型获取所有派生类的对象类型  【在当前运行目录(包含子目录)下的所有程序集中查找】
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <returns></returns>
        static public IEnumerable<Type> GetTypeByInterface<I>()
        {
            string interfaceName = typeof(I).Name;
            foreach (var assembly in GetAssemblyList())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Where(i => i.Name == interfaceName).Count() > 0)
                    {
                        yield return type;
                    }
                }
            }
        }

        /// <summary>
        /// 根据接口类型获取所有派生类的对象实例  【在当前运行目录(包含子目录)下的所有程序集中查找】
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
                    if (type.GetInterfaces().Where(i => i.Name == interfaceName).Count() > 0)
                    {
                        //Todo : 如果构造函数需要参数，需要增加处理逻辑
                        object inst = assembly.CreateInstance(type.FullName);
                        yield return (I)inst;
                    }
                }
            }
        }

        /// <summary>
        /// 根据基类名称获取所有派生类的对象类型  【在当前运行目录(包含子目录)下的所有程序集中查找】
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
                    if (typeInfo != null && typeInfo.BaseType != null && !String.IsNullOrEmpty(typeInfo.BaseType.Name) &&
                        typeInfo.BaseType.Name.Contains(baseName))
                    {
                        yield return type;
                    }
                }
            }
        }

        /// <summary>
        /// 获取在类中拥有指定特性的特性信息列表  【在当前运行目录(包含子目录)下的所有程序集中查找】
        /// </summary>
        /// <typeparam name="T">指定特性类型</typeparam>
        /// <returns></returns>
        static public IEnumerable<T> GetClassAttribute<T>() where T : System.Attribute
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
        /// 获取在方法中拥有指定特性的特性信息列表  【在当前运行目录(包含子目录)下的所有程序集中查找】
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static public IEnumerable<T> GetMethodAttribute<T>() where T : System.Attribute
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
