using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures._7._0
{
    class NamedTuples
    {
        static void Main()
        {
            //Before C# 7.0
            
            Tuple<int, string, double> _tupleObject = Tuple.Create<int, string, double>(10,"hello",100.50);
            Console.WriteLine($"{_tupleObject.Item1},{_tupleObject.Item2},{_tupleObject.Item3}");

            //Named Tuple
            (int number, string name, double sal) _namedTuple = (10, "Hary", 34.5);
            Console.WriteLine($"{_namedTuple.number},{_namedTuple.name},{_namedTuple.sal}");

            var testTuple = (id: "Emp100", Name: "Jack", Age: 25);
           
        }
    }
}
