using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures._7._0
{
    class ThrowExpression
    {
        static void Main(string[] args)
        {

            string arg = args.Length >= 1 ? args[0] :
                                       throw new ArgumentException("You must supply an argument");
            if (Int64.TryParse(arg, out var number))
                Console.WriteLine($"You entered {number:F0}");
            else
                Console.WriteLine($"{arg} is not a number.");

            string name = null;
            string x = name ?? throw new ArgumentNullException(paramName: nameof(name), message: "Name cannot be null");
        }
    }
}    

