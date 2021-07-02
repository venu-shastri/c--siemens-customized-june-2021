using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures._7._0
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Person(string fname, string mname, string lname,
                      string cityName, string stateName)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            City = cityName;
            State = stateName;
        }

        //Return the first and last name.
        public void Deconstruct(out string fname, out string lname)
        {
            fname = FirstName;
            lname = LastName;
        }

        public void Deconstruct(out string fname, out string mname, out string lname)
        {
            fname = FirstName;
            mname = MiddleName;
            lname = LastName;
        }

        public void Deconstruct(out string fname, out string lname,
                                out string city, out string state)
        {
            fname = FirstName;
            lname = LastName;
            city = City;
            state = State;
        }
    }


    class DestructionExample
    {
      static void Main()
        {
            var p = new Person("John", "Quincy", "Adams", "Boston", "MA");
            string fname, lname;
          //  p.Deconstruct(out fname, out lname);
            //var (firstName, lastName) = p;//DeConstruct Method Call
            //var (firstName, middleName, lastName) = p;
            //// Deconstruct the person object.
            var (fName, _, city, _) = p;//p.DeConstruct(out fName,out _,out city,out _)
            Console.WriteLine($"Hello {fName} of {city}!");
            //// The example displays the following output:
            ////      Hello John of Boston!
        }

        static void DiscardWithDestruction()
        {
            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");

            static (string, double, int, int, int, int) QueryCityDataForYears(
                string name, int year1, int year2)
            {
                int population1 = 0, population2 = 0;
                double area = 0;

                if (name == "New York City")
                {
                    area = 468.48;
                    if (year1 == 1960)
                    {
                        population1 = 7781984;
                    }
                    if (year2 == 2010)
                    {
                        population2 = 8175133;
                    }
                    return (name, area, year1, population1, year2, population2);
                }

                return ("", 0, 0, 0, 0, 0);
            }
            // The example displays the following output:
            //      Population change, 1960 to 2010: 393,149
        }

         private static async Task ExecuteAsyncMethods()
            {
                Console.WriteLine("About to launch a task...");
               _= Task.Run(() =>
                {
                    var iterations = 0;
                    for (int ctr = 0; ctr < int.MaxValue; ctr++)
                        iterations++;
                    Console.WriteLine("Completed looping operation...");
                    throw new InvalidOperationException();
                });
                await Task.Delay(5000);
                Console.WriteLine("Exiting after 5 second delay");
            }
            // The example displays output like the following:
            //       About to launch a task...
            //       Completed looping operation...
            //       Exiting after 5 second delay
        
    }
}
