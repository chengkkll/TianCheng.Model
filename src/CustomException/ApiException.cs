using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// Api 异常处理
    /// </summary>
    public class ApiException : System.Exception
    {
        #region 异常属性
        /// <summary>
        /// 错误编码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// http的状态码
        /// </summary>
        public HttpStatusCode HttpStatus { get; }
        /// <summary>
        /// 异常类型
        /// </summary>
        public ApiExceptionType Type { get; set; }
        #endregion

        #region 构造方法
        /// <summary>
        /// 空数据异常
        /// </summary>
        public ApiException()
        {

        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="message">返回的提示文本</param>
        public ApiException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="message">错误提示文本</param>
        /// <param name="ex">截获的异常对象</param>
        public ApiException(string message, Exception ex)
            : base(message, ex)
        {

        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="exceptionType">错误编码</param>
        /// <param name="message">返回的提示文本</param>
        /// <param name="ex">传入的异常信息</param>
        public ApiException(ApiExceptionType exceptionType, string message, Exception ex = null)
            : base(message, ex)
        {
            // 创建异常信息
            Type = exceptionType;
            switch (exceptionType)
            {
                case ApiExceptionType.BadRequest: { HttpStatus = HttpStatusCode.BadRequest; Code = 40001; break; }
                case ApiExceptionType.Required: { HttpStatus = HttpStatusCode.BadRequest; Code = 40002; break; }
                case ApiExceptionType.HasRepeat: { HttpStatus = HttpStatusCode.Forbidden; Code = 40330; break; }
                case ApiExceptionType.RemoveUsed: { HttpStatus = HttpStatusCode.Forbidden; Code = 40331; break; }
                case ApiExceptionType.EmptyData: { HttpStatus = HttpStatusCode.NotFound; Code = 404001; break; }
            }
            // 记录异常信息
            // NLog.Log.Warn(message, this);
        }
        #endregion

        #region 参数错误异常
        /// <summary>
        /// 创建一个请求的参数错误异常
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        /// <returns></returns>
        static public ApiException BadRequest(string message = "", Exception innerException = null)
        {
            return new ApiException(ApiExceptionType.BadRequest, message, innerException);
        }
        /// <summary>
        /// 抛出请求参数错误异常信息
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        static public void ThrowBadRequest(string message = "", Exception innerException = null)
        {
            throw BadRequest(message, innerException);
        }
        #endregion

        #region 无法获取数据异常
        /// <summary>
        /// 创建一个无法获取数据的异常
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        /// <returns></returns>
        static public ApiException EmptyData(string message = "", Exception innerException = null)
        {
            return new ApiException(ApiExceptionType.EmptyData, message, innerException);
        }
        /// <summary>
        /// 抛出无法获取数据异常
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        static public void ThrowEmptyData(string message = "", Exception innerException = null)
        {
            throw EmptyData(message, innerException);
        }
        #endregion

        #region 数据被引用，无法删除异常
        /// <summary>
        /// 数据被引用，无法删除异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException">抛出的异常对象</param>
        /// <returns></returns>
        static public ApiException RemoveUsed(string message = "", Exception innerException = null)
        {
            return new ApiException(ApiExceptionType.RemoveUsed, message, innerException);
        }
        /// <summary>
        /// 抛出数据被引用，无法删除异常
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        static public void ThrowRemoveUsed(string message = "", Exception innerException = null)
        {
            throw RemoveUsed(message, innerException);
        }
        #endregion

        #region 必填项没有填写异常
        /// <summary>
        /// 必填项没有填写异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException">抛出的异常对象</param>
        /// <returns></returns>
        static public ApiException Required(string message, Exception innerException = null)
        {
            return new ApiException(ApiExceptionType.Required, message, innerException);
        }
        /// <summary>
        /// 抛出必填项没有填写异常
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        static public void ThrowRequired(string message = "", Exception innerException = null)
        {
            throw Required(message, innerException);
        }
        #endregion

        #region 连接数据库错误异常
        /// <summary>
        /// 连接数据库错误异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException">抛出的异常对象</param>
        /// <returns></returns>
        static public ApiException ConnectionDB(string message = "", Exception innerException = null)
        {
            return new ApiException(ApiExceptionType.ConnectionDB, message, innerException);
        }
        /// <summary>
        /// 抛出连接数据库错误异常
        /// </summary>
        /// <param name="message">异常错误文本信息</param>
        /// <param name="innerException">抛出的异常对象</param>
        static public void ThrowConnectionDB(string message = "", Exception innerException = null)
        {
            throw ConnectionDB(message, innerException);
        }
        #endregion
    }
}
