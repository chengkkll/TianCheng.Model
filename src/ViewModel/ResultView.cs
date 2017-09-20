using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianCheng.Model
{
    /// <summary>
    /// 通用的返回信息
    /// </summary>
    public class ResultView
    {
        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        #region 操作成功
        /// <summary>
        /// 操作成功
        /// </summary>
        static public ResultView Success(MongoDB.Bson.ObjectId id)
        {
            return new ResultView() { Code = 0, Message = id.ToString() };
        }
        /// <summary>
        /// 操作成功
        /// </summary>
        static public ResultView Success(string msg = "操作成功")
        {
            return new ResultView() { Code = 0, Message = msg };
        }
        #endregion
    }
}
