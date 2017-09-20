using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianCheng.Model
{
    /// <summary>
    /// 业务数据对象
    /// </summary>
    public class BusinessMongoModel : MongoIdModel
    {
        #region 新增信息
        /// <summary>
        /// 创建人ID
        /// </summary>
        [JsonProperty("creater_id")]
        public string CreaterId { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [JsonProperty("creater_name")]
        public string CreaterName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }
        #endregion

        #region 修改信息
        /// <summary>
        /// 更新人ID
        /// </summary>
        [JsonProperty("updater_id")] 
        public string UpdaterId { get; set; }
        /// <summary>
        /// 更新人名称
        /// </summary>
        [JsonProperty("updater_name")]
        public string UpdaterName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("update_date")]
        public DateTime UpdateDate { get; set; }
        #endregion

        #region 业务流程信息
        /// <summary>
        /// 业务流程状态
        /// </summary>
        public ProcessState ProcessState { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        [JsonProperty("is_delete")]
        public bool IsDelete { get; set; }
        #endregion


    }



}
