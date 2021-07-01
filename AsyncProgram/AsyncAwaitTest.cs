using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    class AsyncAwaitTest
    {
        //UI Thread
        public async static void  Button_Click()
        {
            /*  Wrapped in StateMachine */
            Console.WriteLine("Sequence 1");//Sync
           //  Task<string> _searchTask = SearchAsync();
            string result = await SearchAsync();
            int timestamp = await GetServeTimeStampAsync();
            // Task<int> timeStampTask = GetServeTimeStampAsync();
            Task.Delay(5000).Wait();
           
            
            Console.WriteLine("Sequence 2");
            Console.WriteLine("Sequence 3");
        }
        public async static void TestButton_Click()
        {
            /*  Wrapped in StateMachine */
            Console.WriteLine("Sequence 1");//Sync
            string result = await Task.Run(SearchAsync);
            Console.WriteLine("Sequence 2");
            int timestamp = await Task.Run(GetServeTimeStampAsync);
            Console.WriteLine("Sequence 3");
        }

        public static  Task<string> SearchAsync()
        {
            return Task.Run(() => Search());        
        }

        public static string Search()
        {
            Console.WriteLine("Search Async....");
            System.Threading.Thread.Sleep(5000);
            return "SearchResult";

        }
        public static Task<int> GetServeTimeStampAsync()
        {

            return Task.Run(() => GetServerTimeStamp());
        }
        public static int GetServerTimeStamp()
        {
            Console.WriteLine("ServerTime Stamp Async....");
            System.Threading.Thread.Sleep(5000);
            return new Random().Next();
        }

        static void Main()
        {
            Button_Click();
            Console.ReadKey();
        }
    }
}
