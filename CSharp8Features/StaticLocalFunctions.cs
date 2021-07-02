using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Features
{
    class StaticLocalFunctions
    {
        private string field = "Hello";
        public void Test()
        {
            int num = 100;
            LocalFunctionOne();
            LocalFunctionTwo();

            static void LocalFunctionOne()
            {
                Console.WriteLine(num);
            }
            static void LocalFunctionTwo()
            {
                Console.WriteLine(field);
            }
        }
    }
}
