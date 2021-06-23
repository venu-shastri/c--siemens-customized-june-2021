using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusability
{

   
   public class Entity {
    
        public string State { get; set; }
    
       
    }

    class FluentInterfacePattern
    {

        public  FluentInterfacePattern Map()
        {
            return this;
        }
        public FluentInterfacePattern Reduce()
        {
            return this;
        }
        public FluentInterfacePattern Filter()
        {
            return this;
        }
    }

    public static class Enumerable
    {

        public static IEnumerable<T> Map<T>(this IEnumerable<T> source)
        {

            return new List<T>();
        }
        public static IEnumerable<T> Reduce<T>(this IEnumerable<T> source)
        {

            return new List<T>();
        }
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source)
        {

            return new List<T>();
        }
        public static IEnumerable<T> Select<T>(this IEnumerable<T> source)
        {

            return new List<T>();
        }
        public static IEnumerable<T> GetAll<T>(this bool source)
        {

            return new List<T>();
        }
        public static  void ToXml(this Entity obj) { }


    }

    class MainClass
    {
       static void Main__()
        {
            //FluentInterfacePattern _obj = new FluentInterfacePattern().Map().Reduce().Filter();

            //List<string> names = default(List<string>);
            //names.Map().Map().Reduce().Filter().Select();

            //bool IsVaid = true;
            //IsVaid.GetAll<string>().Map().Reduce()

            Entity _entity = new Entity();
            _entity.ToXml();


        }
    }
}
