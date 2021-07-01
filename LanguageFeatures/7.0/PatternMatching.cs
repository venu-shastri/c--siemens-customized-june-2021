using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    /*
     * 
     * 
     * 
     */
    
    
    class PatternMatching
    {
        static void Main()
        {
            object obj = new PatternMatching();
            //oldway
            if(obj is PatternMatching)
            {

                PatternMatching pObj = (PatternMatching)obj;

            }
            //new Way
            //Type: tests input against a type, if so, extracts the value of input into a variable
            if (obj is PatternMatching pNewObj)
            {
              
            }
            //Var pattern
            if (obj is var  varObj)
            {

            }

            switch (obj)
            {
                case PatternMatching pRef when pRef.Equals(obj):break;
            }
        }

      
    }
}
