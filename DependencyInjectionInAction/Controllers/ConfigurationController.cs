using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private IConfigurationRoot configRoot;
        private Models.DbAddressOptions dbAddressInstance;
        public ConfigurationController(IConfiguration root,IOptions<Models.DbAddressOptions> dbAddressOption) { 
            
           this.configRoot =  root as IConfigurationRoot;
            this.dbAddressInstance = dbAddressOption.Value;
        }
        [HttpGet]
        public string Get()
        {
            //System.Text.StringBuilder _builder = new System.Text.StringBuilder();
            //foreach (var provider in this.configRoot.Providers)
            //{
            //    _builder.Append(provider.ToString()).Append(",");
            //}
            //return _builder.ToString();

            //var keyValue=  configRoot["DbAddress:ConnectionString"];
            //return keyValue;

          //  var dbAddress = new Models.DbAddressOptions();
            
            //configRoot.GetSection("DbAddress").Bind(dbAddress);
            return $"{ dbAddressInstance .ConnectionString},{dbAddressInstance.TimeOut}";
                 


        }
    }
}
