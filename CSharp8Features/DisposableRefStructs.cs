using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Features
{
    public unsafe ref struct UnManagedCode
    {
        private int* handle;
        public int* GetHandle()
        {
            return handle;
        }
        public void Dispose() { 
           //Free The Resources
        }

    }
    class DisposableRefStructs
    {
        public void UseRefStruct()
        {
            using(var handle=)
        }
    }
}
