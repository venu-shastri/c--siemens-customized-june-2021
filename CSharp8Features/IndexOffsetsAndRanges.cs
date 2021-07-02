using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Features
{
    /*   Range Operator: ..
     *   Index Operator: ^
     *   Start of Range is Inclusive
     *   End of Range is Exclusive
     *   Indexing From the start is 0 based
     *   Indexing from the end is relative to the length
     */ 
    class IndexOffsetsAndRanges
    {
        void RangeTest()
        {
            var number = Enumerable.Range(1, 10).ToArray();
            var copy = number[0..^0]; //UpperBound is Exculsive
            var allButFirst = number[1..];
            var lastItemRange = number[^1..];
            var lastItem = number[^1];
            var lastThree = number[^3..];

            Index middle = 4;
            Index threeFromEnd = ^3;
            Range customRange = middle..threeFromEnd;
            var cutsom = number[customRange];
        }
    }
}
