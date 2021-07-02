using System;
using System.Linq;
namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context=new DeviceContext())
            {
                Console.WriteLine("Inserting a new Device");
                context.Add(new Device { Id = "D1", Name = "ABC" }); 
                context.SaveChanges();

                // Read
                Console.WriteLine("Querying for a Device");
                var device = context.Devices.OrderBy(d=>d.Id).First();
                Console.WriteLine(device.Name);

                
                
            }
        }
    }
}
