using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// api 异常类型枚举
    /// </summary>
    public enum ApiExceptionType
    {
        /// <summary>
        /// 未定义异常
        /// </summary>
        None = 0,
        /// <summary>
        /// 必填项
        /// </summary>
        Required = 1,
        /// <summary>
        /// 有重复项
        /// </summary>
        HasRepeat = 2,
        /// <summary>
        /// 数据不存在
        /// </summary>
        NotExist = 4,
        /// <summary>
        /// 数据已使用不允许删除
        /// </summary>
        RemoveUsed = 8,
        /// <summary>
        /// 错误的请求数据
        /// </summary>
        BadRequest = 16,
        /// <summary>
        /// 没有查询数据
        /// </summary>
        EmptyData = 32,


        /// <summary>
        /// 链接数据库失败
        /// </summary>
        ConnectionDB = 4096,

    }
}
