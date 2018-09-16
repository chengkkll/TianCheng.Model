using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    public interface IBusinessModel<T> : IIdModel<T>
    {
        #region 新增信息
        /// <summary>
        /// 创建人ID
        /// </summary>
        [JsonProperty("createrId")]
        string CreaterId { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [JsonProperty("createrName")]
        string CreaterName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("createDate")]
        DateTime CreateDate { get; set; }
        #endregion

        #region 修改信息
        /// <summary>
        /// 更新人ID
        /// </summary>
        [JsonProperty("updaterId")]
        string UpdaterId { get; set; }
        /// <summary>
        /// 更新人名称
        /// </summary>
        [JsonProperty("updaterName")]
        string UpdaterName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updateDate")]
        DateTime UpdateDate { get; set; }
        #endregion

        #region 业务流程信息
        /// <summary>
        /// 业务流程状态
        /// </summary>
        ProcessState ProcessState { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [JsonProperty("releaseDate")]
        DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        [JsonProperty("isDelete")]
        bool IsDelete { get; set; }
        #endregion
    }
}
