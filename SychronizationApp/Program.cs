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
        public void Dispose()
        {
           // Relase  Resources
        }

        public void Open() { }
        public void Read() { }
        public void Write() { }

    }


    public class Client
    {
        public void ProcesFile()
        {
           
            //using (FileHandle _handle = new FileHandle())
            //{

            //    _handle.Open();
            //    _handle.Read();

            //}
                
        }
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
            lock (_syncUpdateAndAppend)
            {

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Append State in Action ");
                    Thread.Sleep(1000);

                }
            }
        }
        //T3,T4
        //[System.Runtime.CompilerServices.MethodImpl
          //  (System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void GetState() {
            Monitor.Enter(_syncGetState);
            try
            {
                //Critical Section 
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Get State in Action {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                    if (i == 5) { return; }

                }
            }
            finally
            {
                Monitor.Exit(_syncGetState);
            }

        }

        
    }

    public static  class BackgroundTasks
    { 
        public static void Task1() {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Task1 .....");
                System.Threading.Thread.Sleep(1000);
            }
          }
        public static void Task2() {
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Task2 .....");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void Task3()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Task2 .....");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            //  new Thread(Singleton.Instance.UpdateState).Start();
            //new Thread(Singleton.Instance.AppendState).Start();
            // new Thread(Singleton.Instance.GetState).Start();
            //new Thread(Singleton.Instance.GetState).Start();

            AutoResetEvent _signal = new AutoResetEvent(false);
            

                System.Threading.ThreadPool.QueueUserWorkItem((obj) => { BackgroundTasks.Task1(); });
                System.Threading.ThreadPool.QueueUserWorkItem((obj) => { BackgroundTasks.Task2(); });
                System.Threading.ThreadPool.QueueUserWorkItem((obj) => { BackgroundTasks.Task3(); });
                //WaitHandle.WaitAny(/* Array of WaitHandles */);
                //WaitHandle.WaitAll(/* Array of WaitHandles */);


        }
    }
}
