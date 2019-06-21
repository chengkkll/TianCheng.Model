using System;

namespace TianCheng.Model
{
    /// <summary>
    /// 用Guid来做ID的实体对象基类
    /// </summary>
    public class GuidModel : IIdModel<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 获取ID的字符串格式
        /// </summary>
        public string IdString
        {
            get
            {
                return Id;
            }
        }
        /// <summary>
        /// 判断Id是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty
        {
            get
            {
                return !Check(this.Id);
            }
        }

        /// <summary>
        /// 检查指定ID是否正确
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true正确ID   false不可用ID</returns>
        public bool CheckId(string id)
        {
            return Check(id);
        }

        /// <summary>
        /// 检查id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Check(string id)
        {
            return !string.IsNullOrWhiteSpace(id);
        }

        /// <summary>
        /// 设置对象ID。如果传入的ID无效，返回false
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool SetId(string strId)
        {
            if (!Check(strId))
            {
                return false;
            }
            this.Id = strId;
            return true;
        }
    }
}
