using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    class Base { }
    class A : Base { public void Fun() { } }
    class B : Base { public string Name { get; set; }
        class C : Base { }
        class PatternMatching
        {
            public string name;
            static void Main_old()
            {
                object data = Console.ReadLine();
                if (data is int)
                {


                }

                string input = "1000";
                int _;
                if(Int32.TryParse(input,out _))
                {

                }

                System.Collections.ArrayList _objList = new System.Collections.ArrayList();
                _objList.Add(new A());
                _objList.Add(new B() { Name = "Tom" });
                _objList.Add(new C());
                _objList.Add("string");



                foreach (object item in _objList)
                {

                    //Old Way
                    switch (item.GetType().Name)
                    {
                        case "A": ((A)item).Fun(); break;
                        case nameof(B): break;
                    }
                    switch (item)
                    {
                        case A aRef: aRef.Fun(); break;
                        case B bRef when bRef.Name.StartsWith("Siemens"): break;
                    }
                }

                object obj = new PatternMatching();
                //oldway
                if (obj is PatternMatching)
                {

                    PatternMatching pObj = (PatternMatching)obj;

                }
                //new Way
                //Type: tests input against a type, if so, extracts the value of input into a variable
                if (obj is PatternMatching pNewObj)
                {


                }
                //Var pattern
                if (obj is var varObj)
                {
                    varObj.
                }

                switch (obj)
                {
                    case PatternMatching pRef when pRef.Equals(obj): break;
                }
            }

            static void Main()
            {
                List<Base> _objects = new List<Base>();
                _objects.Add(new A());
                _objects.Add(new B());
                _objects.Add(new C());
            }
            static void Abstraction(Base baseRef)
            {
                switch (baseRef)
                {
                    case A:break;

                }
            }


        }
    }
}
