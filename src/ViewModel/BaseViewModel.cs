﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

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

        ///// <summary>
        ///// 显示的名称
        ///// </summary>
        //public string name { get; set; }
    }
}