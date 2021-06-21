using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyDelegate
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }
        public string  Location { get; set; }
    }
    public class EmployeeInMemoryRepository
    {
        List<Employee> _employees = new List<Employee>
        {
            new Employee { ID="E100", Name="tom", Age=35, Location="BLR"},
            new Employee { ID="E200", Name="Hary", Age=38, Location="CHN"},
            new Employee { ID="E300", Name="Jack", Age=45, Location="HYD"},
            new Employee { ID="E400", Name="James", Age=55, Location="DEL"}
        };
        public IEnumerable<Employee> GetAll() { return _employees; }
    }
    public class EmploySearchService
    {
        EmployeeInMemoryRepository _repo = new EmployeeInMemoryRepository();
        public IEnumerable<Employee> SearchById(string id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Employee> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Employee> SearchByLocation(string location)
        {
            throw new NotImplementedException();
        }
    }
    class Problem
    {
    }
}
