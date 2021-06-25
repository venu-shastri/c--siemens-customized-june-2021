using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SychronizationApp
{
    public class FileHandle
    {

    }
    //[System.Runtime.Remoting.Contexts.Synchronization]
    public class Singleton //:System.ContextBoundObject
    {
        System.Object _syncUpdateAndAppend = new object();
        System.Object _syncGetState = new object();

        FileHandle _resource = new FileHandle();
        public  static readonly Singleton Instance = null;
        static Singleton()
        {
            Instance = new Singleton();
        }
        

       
        private Singleton() { }

        string state;
        private bool disposedValue;

        //T1
        //[System.Runtime.CompilerServices.MethodImpl
          //  (System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void UpdateState() {

            Monitor.Enter(_syncUpdateAndAppend);
        for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Update State in Action ");
                Thread.Sleep(1000);
                
            }
            Monitor.Exit(_syncUpdateAndAppend);
        
        }

        //T2
        //[System.Runtime.CompilerServices.MethodImpl
          //  (System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void AppendState() {
            Monitor.Enter(_syncUpdateAndAppend);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Append State in Action ");
                Thread.Sleep(1000);

            }
            Monitor.Exit(_syncUpdateAndAppend);
        }
        //T3,T4
        //[System.Runtime.CompilerServices.MethodImpl
          //  (System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void GetState() {
            Monitor.Enter(_syncGetState);
            //Critical Section 
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Get State in Action {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);

            }
            Monitor.Exit(_syncGetState);

        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Singleton.Instance.UpdateState).Start();
            new Thread(Singleton.Instance.AppendState).Start();
            new Thread(Singleton.Instance.GetState).Start();
            new Thread(Singleton.Instance.GetState).Start();

        }
    }
}
