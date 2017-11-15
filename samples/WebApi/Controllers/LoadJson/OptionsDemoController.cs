using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianCheng.Model;

namespace WebApi.Controllers.LoadJson
{
    [Route("api/setting")]
    public class OptionsDemoController
    {
        DatabaseInfo _di;

        public OptionsDemoController(IOptions<DatabaseInfo> option)
        {
            _di = option.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("option")]
        public string ByOption()
        {
            // 使用IOptions的方式：
            // 1、 在Startup类中增加:
            //      services.AddOptions();
            //      services.Configure<Controllers.DatabaseInfo>(Configuration.GetSection("DatabaseInfo"));
            // 问题： 更新文件是，无法清除缓存，重新获取数据
            return _di.ToJson();
        }
    }
}
