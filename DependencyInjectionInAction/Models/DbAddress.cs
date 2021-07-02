using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionInAction.Models
{
    //OptionsPattern
    public class DbAddressOptions
    {
        public const string DbAddress = "DbAddress";
        public string ConnectionString { get; set; }
        public int TimeOut { get; set; }
    }
}
