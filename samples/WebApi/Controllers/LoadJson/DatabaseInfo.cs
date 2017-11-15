using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class DatabaseInfo 
    {
        /// <summary>
        /// 
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
    }
}
