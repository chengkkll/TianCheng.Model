using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// String -> ObjectId
    /// </summary>
    public class StringToObjectIdConverter : ITypeConverter<string, MongoDB.Bson.ObjectId>
    {
        /// <summary>
        /// String -> ObjectId
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public MongoDB.Bson.ObjectId Convert(string source, MongoDB.Bson.ObjectId destination, ResolutionContext context)
        {
            return source.ToObjectId();
        }
    }
    /// <summary>
    ///  ObjectId -> String
    /// </summary>
    public class ObjectIdToStringConverter : ITypeConverter<MongoDB.Bson.ObjectId, string>
    {
        /// <summary>
        ///  ObjectId -> String
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(MongoDB.Bson.ObjectId source, string destination, ResolutionContext context)
        {
            return source.ToString();
        }
    }
}
