using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Features
{

   public class Resource : IDisposable
    {
        public void Dispose() { }
    }
    public class UsingDeclarartions
    {
        public static void UseResource()
        {
            //Earlier Syntax
            using(Resource resource =new Resource()) { }
            //New Syntax
            using Resource res = new Resource();
        }
       

    }
}
