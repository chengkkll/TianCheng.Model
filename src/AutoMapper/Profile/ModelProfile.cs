using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// 基础信息的AutoMapper转换
    /// </summary>
    public class ModelProfile : Profile, IAutoProfile
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public ModelProfile()
        {
            Register();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Register()
        {
            CreateMap<string, DateTime>().ConvertUsing(new StringToDateTimeConverter());
            CreateMap<DateTime, string>().ConvertUsing(new DateTimeToStringConverter());
            CreateMap<string, MongoDB.Bson.ObjectId>().ConvertUsing(new StringToObjectIdConverter());
            CreateMap<MongoDB.Bson.ObjectId, string>().ConvertUsing(new ObjectIdToStringConverter());
            CreateMap<string, DateTime?>().ConvertUsing(new StringToDateTimeNullConverter());
            CreateMap<DateTime?, string>().ConvertUsing(new DateTimeNullToStringConverter());

        }


    }

}
