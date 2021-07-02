using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reusability.Siemens.Linq;

namespace Reusability
{
    class Program
    {
        static void Main(string[] args)
        {
            //Source
           
           IEnumerable<string>  names = new string[] { "Bengaluru", "Mysore", "Delhi", "Chennai", "Mumbai" };

            //Anonymous Type

            /* 
             * var - implicitly typed variable
             * Scope - local variable 
             * Must be initialized @complie time 
             * */

            var obj = new { Name = "Tom", Age = 10 };
            Console.WriteLine(obj.GetType().FullName);
          
            var projectionResult=  names.Select((string item) => { return new { Name = item, Length = item.Length }; });
            var  neprojectionResult = names.Select((string item) => { return new { Name = item, InvertedName = item.Reverse().ToList().ToString(), UpperCase = item.ToUpper() }; });
                 

            names.SelectQuery(new Func<string, bool>(CheckStringEndsWithi));
           // MSIL Code ->  Reusability.Siemens.Linq.Enumerable.SelectQuery(names, new Func<string, bool>(CheckStringEndsWithi));

            SelectQuery<string>(names, CheckStringStartWith("i"));
            
            List<string> _namesList= names.ToList();
            SelectQuery<string>(_namesList,CheckStringStartWith("e"));

            
        }
        // Encapsulate predicate  -> pure function

        public static  Func<string, bool> CheckStringStartWith(string content)
        {
            //Func<string, bool> predicate = (string item) => { return item.StartsWith(content); };
            bool filter(string item)
            {
                return item.StartsWith(content);
            }
            return filter;
            //return predicate;
        }
        public static bool CheckStringEndsWithi(string item)
        {
            return item.EndsWith("i");
        }
        public static bool CheckStringEndsWithe(string item)
        {
            return item.EndsWith("e");
        }
        public List<string> SelectQuery(string[] source)
        {
            List<string> result = new List<string>();
            //Iterator
            for (int i = 0; i < source.Length; i++)
            {
                //Predicate
                if (source[i].EndsWith("i"))
                {
                    result.Add(source[i]);
                }
            }
            return result;

        }

        //pure function
        public List<string> SelectQuery(string[] source,Func<string,bool> predicate)
        {
            List<string> result = new List<string>();
            //Iterator
            for (int i = 0; i < source.Length; i++)
            {
                //Predicate
                if (predicate.Invoke(source[i]));
                {
                    result.Add(source[i]);
                }
            }
            return result;

        }
        public List<T> SelectQuery<T>(T[] source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            //Iterator
            for (int i = 0; i < source.Length; i++)
            {
                //Predicate
                if (predicate.Invoke(source[i])) ;
                {
                    result.Add(source[i]);
                }
            }
            return result;

        }

        //pure function 
        //Parameters 
            // predicate
            //source
            //Parametric Polymorphism
            //iterator Pattern
            //LINQ Operator 
        public static  List<T> SelectQuery<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                }
            }
                
            return result;

        }
    }
}

