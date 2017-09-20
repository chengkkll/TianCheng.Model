using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// 分页查询结果
    /// </summary>
    /// <typeparam name="T">数据Dto</typeparam>
    [JsonObject(MemberSerialization.OptIn)]
    public class PagedResult<T>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="data">本页数据列表</param>
        /// <param name="pagination">分页信息</param>
        public PagedResult(List<T> data, PagedResultPagination pagination)
        {
            Data = data;
            Pagination = pagination;
        }

        /// <summary>
        /// 分页信息
        /// </summary>
        private PagedResultPagination _Pagination = null;
        /// <summary>
        /// 分页信息
        /// </summary>
        [JsonProperty("pagination")]
        public PagedResultPagination Pagination
        {
            get { return _Pagination; }
            set { _Pagination = value ?? new PagedResultPagination(); }
        }

        /// <summary>
        /// 本页数据
        /// </summary>
        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }

}
