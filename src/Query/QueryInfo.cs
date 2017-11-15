using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// 查询条件基类
    /// </summary>
    public class QueryInfo
    {
        /// <summary>
        /// 排序条件
        /// </summary>
        [Obsolete("过时的版本，新版中会删除")]
        [JsonProperty("order")] 
        public string OrderBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private QuerySort _Sort = new QuerySort();
        /// <summary>
        /// 排序规则
        /// </summary>
        [JsonProperty("sort")]
        public QuerySort Sort { get { return _Sort; } set { _Sort = value; } }


        private QueryPagination _Pagination = new QueryPagination();
        /// <summary>
        /// 分页信息
        /// </summary>
        [JsonProperty("pagination")]
        public QueryPagination Pagination { get { return _Pagination; } set { _Pagination = value; } }
    }

 
}
