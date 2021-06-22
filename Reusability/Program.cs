using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusability
{
    class Program
    {
        static void Main(string[] args)
        {
            //Source
            string[] names = new string[] { "Bengaluru", "Mysore", "Delhi", "Chennai", "Mumbai" };

            SelectQuery<string>(names, new Func<string, bool>(CheckStringEndsWithi));
            
            List<string> _namesList= names.ToList();
            SelectQuery<string>(_namesList, new Func<string, bool>(CheckStringEndsWithe));

            
        }
        // Encapsulate predicate  -> pure function
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

