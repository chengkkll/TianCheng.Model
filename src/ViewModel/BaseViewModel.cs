using Newtonsoft.Json;

namespace TianCheng.Model
{
    /// <summary>
    /// 查看对象基类
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// ID 新增时不需要传值，修改的时候需要传递
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 显示的名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
