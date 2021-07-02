using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures._7._0
{
    class OutVariable
    {
        static void Main_()
        {
            //old way 
            int outVarialble;
            TestOutVaraible(out outVarialble);
            //NewWay
            TestOutVaraible(out int newOutVaraible);
            Console.WriteLine(newOutVaraible);

        }
        static void TestOutVaraible(out int number)
        {

            number = new Random().Next();
            _=  number % 2 == 0 ? "even" : throw new Exception("Invalid Number");
            if (number % 2 == 0)
            {
                throw new Exception("Invalid Number");//statement
            }
            

        }
    }
}
