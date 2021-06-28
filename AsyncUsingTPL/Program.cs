using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //TPL

namespace AsyncUsingTPL
{
    class Program
    {
        /*
         * Exception Handling
         * Cancellation Support
         * Parent-Children
         * Task Chaining 
         */
        static void Main_old(string[] args)
        {
            Task _asyncTask1 = new Task(Task1); // Action
            
            Task _asyncTask2= new Task(Task2,new object()); // Action

            Task<string> _asyncTask3 = new Task<string>(Task3); //Func<string>
            Task<string> _asyncTask4 = new Task<string>(Task4,new Object()); //Func<string>

            _asyncTask1.Start();
            _asyncTask2.Start();
            _asyncTask3.Start();
            _asyncTask4.Start();
            try
            {
                Task.WaitAll(_asyncTask1, _asyncTask2, _asyncTask3, _asyncTask4);
            }
            catch(AggregateException ex)
            {
                foreach(Exception exception in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                        
                }
            }

            //.....
            //try
            //{
            //    _asyncTask1.Wait();
            //}
            //catch(AggregateException ex)
            //{
            //   AggregateException flatten= ex.Flatten();
            //    foreach(Exception exception in flatten.InnerExceptions)
            //    {
            //        Console.WriteLine(exception.Message);
            //    }
            //}

                

          // string result= _asyncTask3.Result;
        }

        static void Main_latest()
        {
            Task _parentTask = new Task(ParentTask);
            _parentTask.Start();
            try
            {
                _parentTask.Wait();
            }catch(AggregateException ex)
            {
                var aggregatedExceprion = ex.Flatten().InnerExceptions;
               foreach(var exception in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                        
                }
            }
        }
        static void Task1() { 
        
            for(int i = 0; i < 10; i++)
            {
                if (i == 5) { throw new System.IO.FileNotFoundException("Task1 Exception"); }
            }
        
        }
        static void Task2(object state) {
            for (int i = 0; i < 10; i++)
            {
                if (i ==8) { throw new Exception("Task2 Exception"); }
            }

        }
        static string Task3() {

            for (int i = 0; i < 10; i++)
            {
                if (i == 8) { throw new Exception("Task3 Exception"); }
            }
            return default(string); }
        static string Task4(object state) {

            for (int i = 0; i < 10; i++)
            {
                if (i == 8) { throw new Exception("Task4 Exception"); }
            }
            return default(string); 
        }

        static void ParentTask()
        {
            Console.WriteLine("ParentTask Begin");
            Task _childTask = new Task(ChildTask,TaskCreationOptions.AttachedToParent);
            _childTask.Start();
            Console.WriteLine("ParentTask End");
        }
        static void ChildTask() {

            Console.WriteLine("ChildTask Begin");
            Task _descedentChildTask = new Task(DescedentChildTask, TaskCreationOptions.AttachedToParent);
            _descedentChildTask.Start();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("ChildTask End");
            throw new Exception("Child Exception");
            
        }
        static void DescedentChildTask() {

            Console.WriteLine("DescedentChildTask Begin");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("DescedentChildTask End");
            throw new Exception("DescentChild Exception");

        }
    }
}
