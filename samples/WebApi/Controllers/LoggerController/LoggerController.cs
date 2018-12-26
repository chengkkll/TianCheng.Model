using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/logger")]
    public class LoggerController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("debug")]
        public string Debug()
        {
            TianCheng.Model.CommonLog.Logger.Debug("test tiancheng log debug");
            return "ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("warn")]
        public string Warn()
        {
            TianCheng.Model.CommonLog.Logger.Warn("warn");
            return "ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("error")]
        public string Error()
        {
            TianCheng.Model.CommonLog.Logger.Error("error");
            return "ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("fatal")]
        public string Fatal()
        {
            TianCheng.Model.CommonLog.Logger.Fatal("fatal");
            return "ok";
        }
    }
}
