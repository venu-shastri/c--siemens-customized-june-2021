using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    /* Thread- > DataStructure -> Describe "Execution Path[ functions ] "
     * ID,Name,priority,apartment, culture ,state,stack
     *
     */
    class Program
    {
        //Caller
        static void Main_(string[] args)
        {
            // Search("abc");//Synchrnous Program
            //begin New Thread(Execution Path) -> Search
           System.Threading.Thread _mainExecutionPath= System.Threading.Thread.CurrentThread;
            Console.WriteLine($"Main Method Execution - Thread {System.Threading.Thread.CurrentThread.ManagedThreadId} Backgorund Mode ?{System.Threading.Thread.CurrentThread.IsBackground}");
            //System.Threading.Thread _searchExecutionPath = new System.Threading.Thread(
            //    new System.Threading.ParameterizedThreadStart(SearchAsync))
            //{  IsBackground=true};
            //_searchExecutionPath.Start(new System.Random().Next().ToString());

            System.Threading.WaitCallback backGroundTaskFuncObj = new System.Threading.WaitCallback(SearchAsync);
            System.Threading.ThreadPool.QueueUserWorkItem(backGroundTaskFuncObj, new System.Random().Next().ToString());

            
          //  _searchExecutionPath.Join();
            Console.WriteLine("End OF Main Execution Path");

            //string result= Search(new System.Random().Next().ToString());
            //Console.WriteLine($"Search Result {result} ");
            Console.ReadLine();
           

        }
        //Calle
        static void SearchAsync(object args)
        {
           string result= Search(args.ToString());
        }
        static string Search(string key)
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Search Done  BY Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId} Background Mode ?{System.Threading.Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(1000);
            }
            return key;
        }
    }
}
