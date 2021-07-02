using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionInAction.Extensibility
{
    public static  class CustomConfigurationProviderExtesnions
    {
        public static void AddMongo(this IConfigurationBuilder builder,string connection)
        {
            ///builder.Add()
                

        }
        public static void AddCsvFile(this IConfigurationBuilder builder,string path)
        {

        }
    }
}
