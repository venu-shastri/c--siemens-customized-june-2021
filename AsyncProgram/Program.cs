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
        static void Main(string[] args)
        {
            // Search("abc");//Synchrnous Program
            //begin New Thread(Execution Path) -> Search
           System.Threading.Thread _mainExecutionPath= System.Threading.Thread.CurrentThread;
            Console.WriteLine($"Main Method Execution - Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            System.Threading.Thread _searchExecutionPath = new System.Threading.Thread(
                new System.Threading.ParameterizedThreadStart(SearchAsync));
            _searchExecutionPath.Start(new System.Random().Next().ToString());
            Console.WriteLine("End OF Main Execution Path");
            
           //string result= Search(new System.Random().Next().ToString());
            //Console.WriteLine($"Search Result {result} ");
           

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
                Console.WriteLine($"Search Done  BY Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                System.Threading.Thread.Sleep(1000);
            }
            return key;
        }
    }
}
