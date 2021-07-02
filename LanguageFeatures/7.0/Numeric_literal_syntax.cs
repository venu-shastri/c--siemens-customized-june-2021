using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures._7._0
{
    class Numeric_literal_syntax
    {
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        static void Main()
        {
            
            var lit1 = 478_1254_3698_44;
            var lit2 = 4781254369844;

            

            //C# also come with binary literal for bunary values

            var binLit = 1100_1011_0100_1010_1001;
        }
    }
}
