using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncUsingTPL
{
    class TaskChaining
    {
        static void Main()
        {
           
            while (true)
            {
                
                SendNetworkRequest();
                System.Threading.Thread.Sleep(12000);
            }
        }
        static void SendNetworkRequest()
        {
            Task _httpRequest = new Task(() => {

                Console.WriteLine("Http Request Begin.....");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Http Request End.....");

            });
          Task<int> processResponseTask=  _httpRequest.ContinueWith<int>((pt) =>
            {
                Console.WriteLine("Process Response  Begin.....");
                Console.WriteLine("Process Response  End.....");
                return new Random().Next(1, 5);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

          Task _validateResponseTask=  processResponseTask.ContinueWith((pt) => {
                Console.WriteLine("Validate Response  Begin.....");
                int result = pt.Result;
              Console.WriteLine(result);
                Console.WriteLine("Validate Response  End.....");
                if (result % 2 != 0) { throw new Exception("Erro in HttpResponse"); }


            },TaskContinuationOptions.OnlyOnRanToCompletion);

            _validateResponseTask.ContinueWith((pt) => {
                Console.WriteLine("ProcessData Task   Begin.....");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("ProcessData Task  End.....");

            }, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.NotOnFaulted);

            _validateResponseTask.ContinueWith((pt) => {
                Console.WriteLine("Log Task   Begin.....");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Log Task  End.....");

            },  TaskContinuationOptions.OnlyOnFaulted);

            _httpRequest.Start();
        }
    }
}
