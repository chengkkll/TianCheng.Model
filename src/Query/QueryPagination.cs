using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianCheng.Model
{

    /// <summary>
    /// 分页对象
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class QueryPagination
    {
        /// <summary>
        /// 要获取数据的页号
        /// </summary>
        [Range(1,int.MaxValue, ErrorMessage ="当前页号必须是正整数")]
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        /// 每页最多显示的数据条数
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "每页数据条数必须是正整数")]
        [JsonProperty("max")]
        public int PageMaxRecords { get; set; }

        /// <summary>
        /// 默认每页记录数
        /// </summary>
        public const int DefaultPageMaxRecords = 10;
        /// <summary>
        /// 默认的分页信息
        /// </summary>
        static public QueryPagination DefaultObject
        {
            get
            {
                QueryPagination pa = new QueryPagination();
                pa.Index = 1;
                pa.PageMaxRecords = DefaultPageMaxRecords;
                return pa;
            }
        }

        /// <summary>
        /// 一页内显示所有数据
        /// </summary>
        static public QueryPagination OnePage
        {
            get
            {
                QueryPagination pa = new QueryPagination();
                pa.Index = 1;
                pa.PageMaxRecords = 10000;
                return pa;
            }
        }
    }
}
