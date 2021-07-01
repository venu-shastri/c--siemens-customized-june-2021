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
            number = 10;

        }
    }
}
