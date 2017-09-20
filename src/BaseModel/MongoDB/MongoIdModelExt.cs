using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace TianCheng.Model
{
    /// <summary>
    /// MongoId 的扩展方法
    /// </summary>
    static public class MongoIdModelExt
    {
        /// <summary>
        /// 获取对象的ID列表
        /// </summary>
        /// <param name="objectList"></param>
        /// <returns></returns>
        static public IEnumerable<string> ToIdList<T>(this List<T> objectList) where T : MongoIdModel
        {
            foreach (MongoIdModel model in objectList)
            {
                yield return model.Id.ToString();
            }
        }
        /// <summary>
        /// string -> mongo的ObjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public ObjectId ToObjectId(this string id)
        {
            ObjectId _id = ObjectId.Empty;
            if (ObjectId.TryParse(id, out _id))
            {
                return _id;
            }
            return ObjectId.Empty;
        }
        /// <summary>
        /// string -> MongoIdModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public MongoIdModel ToMongoId(this string id)
        {
            MongoIdModel model = new MongoIdModel();
            model.Id = id.ToObjectId();
            return model;
        }
        /// <summary>
        /// 检查id是否为一个有效的MongoId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public bool CheckMongoId(string id)
        {
            ObjectId _id = ObjectId.Empty;
            return ObjectId.TryParse(id, out _id);
        }
    }
}
