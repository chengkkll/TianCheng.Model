using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianCheng.Model;

namespace WebApi.Controllers
{
    public class AppsettingCaching : CachingFromFile<DatabaseInfo>
    {
        protected override string CacheKey { get { return "AppsettingCaching_DatabaseInfo"; } }

        protected override string DependentFile { get { return "appsettings.json"; } }

        protected override DatabaseInfo ReadFile(string fileContent)
        {
            var jSettings = JObject.Parse(fileContent)["DatabaseInfo"];
            DatabaseInfo di = JsonConvert.DeserializeObject<DatabaseInfo>(jSettings.ToString());
            return di;
        }
    }


}
