namespace TianCheng.Model
{
    /// <summary>
    /// Id为int类型的实体基类
    /// </summary>
    public class IntModel : IIdModel<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取ID的字符串格式
        /// </summary>
        public string IdString
        {
            get
            {
                return Id.ToString();
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
                return Check(Id);
            }
        }

        /// <summary>
        /// 检查指定ID是否正确
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true正确ID   false不可用ID</returns>
        public bool CheckId(int id)
        {
            return Check(id);
        }

        /// <summary>
        /// 检查id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Check(int id)
        {
            return id != 0;
        }

        ///// <summary>
        ///// 将字符串转成ID
        ///// </summary>
        ///// <param name="strId"></param>
        ///// <returns></returns>
        //public int GetId(string strId)
        //{
        //    if(int.TryParse(strId,out int id))
        //    {
        //        return id;
        //    }
        //    return 0;
        //}

        /// <summary>
        /// 设置对象ID，如果传入的ID无效，返回false
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool SetId(string strId)
        {
            // 检查ID是否有效
            if (!int.TryParse(strId, out int id))
            {
                return false;
            }
            if (!Check(id))
            {
                return false;
            }

            this.Id = id;
            return true;
        }
    }
}
