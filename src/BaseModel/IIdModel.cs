using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// ID实体基类接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdModel<T>
    {
        /// <summary>
        /// Id
        /// </summary>
        T Id { get; set; }
        /// <summary>
        /// 获取ID的字符串格式
        /// </summary>
        string IdString { get; }

        /// <summary>
        /// 判断ID是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty { get; }

        /// <summary>
        /// 检查指定ID是否正确
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool CheckId(T id);
        ///// <summary>
        ///// 根据字符串获取ID
        ///// </summary>
        ///// <param name="strId"></param>
        ///// <returns></returns>
        //T GetId(string strId);
        /// <summary>
        /// 设置对象ID，如果传入的ID无效，返回false
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        bool SetId(string strId);


    }
}
