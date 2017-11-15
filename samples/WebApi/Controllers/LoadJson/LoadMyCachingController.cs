using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianCheng.Model;

namespace WebApi.Controllers
{
    [Route("api/setting")]
    public class LoadMyCachingController
    {
        /// <summary>
        /// 根据key获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("get/{key}")]
        public string Get(string key)
        {
            CachingHelper ch = new CachingHelper();
            ch.SetCache<string>(key, "abc");
            return ch.GetCache<string>(key);
        }

        /// <summary>
        /// 获取缓存的文件，如果文件修改时，缓存会被重置
        /// </summary>
        /// <returns></returns>
        [HttpGet("caching")]
        public string Get()
        {
            var ac = new AppsettingCaching();
            return ac.GetCache().ToJson();
        }
    }
}
