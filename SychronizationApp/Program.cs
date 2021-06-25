using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SychronizationApp
{
    public class Singleton
    {
        public static readonly Singleton Instance = new Singleton();
        private Singleton() { }

        string state;

        public void UpdateState() { 
        for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Update State in Action ");
                Thread.Sleep(1000);
                
            }
        
        }

        public void AppendState() {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Append State in Action ");
                Thread.Sleep(1000);

            }
        }
        public void GetState() {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Get State in Action ");
                Thread.Sleep(1000);

            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Singleton.Instance.UpdateState).Start();
            new Thread(Singleton.Instance.AppendState).Start();
            new Thread(Singleton.Instance.GetState).Start(); 
            
        }
    }
}
