
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
        public int Code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
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
