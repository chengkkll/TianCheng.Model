using Newtonsoft.Json;
using System;

namespace TianCheng.Model
{
    /// <summary>
    /// Json 工具类
    /// </summary>
    static public class JsonTools
    {
        #region ToJson
        /// <summary>
        /// 根据对象信息生成Json串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 根据对象信息生成Json串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj)
        {
            return ObjectToJson(obj);
        }
        #endregion

        #region ToObject
        /// <summary>
        /// 从一个Json串生成对象信息
        /// </summary>
        /// <typeparam name="T">生成对象的类型</typeparam>
        /// <param name="jsonString">Json字符串</param>
        /// <returns></returns>
        static public T JsonToObject<T>(this string jsonString) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// 从一个Json串生成对象信息
        /// </summary>
        /// <param name="jsonString">json字符串</param>
        /// <param name="objType">生成对象的类型</param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, Type objType)
        {
            return JsonConvert.DeserializeObject(jsonString, objType);
        }
        #endregion
    }
}
