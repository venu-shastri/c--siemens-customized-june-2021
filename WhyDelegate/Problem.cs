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
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
    }
    public class EmployeeInMemoryRepository:IEmployeeRepository
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

    public interface IFilter
    {
        IEnumerable<Employee> Filter(IEnumerable<Employee> source);
    }

    public class SearchByIdFilter:IFilter
    {
       public string ID { get; set; }

        public IEnumerable<Employee> Filter(IEnumerable<Employee> source)
        {
           foreach(Employee item in source)
            {
                if (item.ID == ID)
                {

                    yield return item;
                }
            }
        }
    }

    public class SearchByNameFilter : IFilter
    {
        public string Name { get; set; }
        public IEnumerable<Employee> Filter(IEnumerable<Employee> source)
        {
            foreach (Employee item in source)
            {
                if (item.Name == Name)
                {

                    yield return item;
                }
            }

        }
    }
    public class EmploySearchService
    {
        IEmployeeRepository _repo = null;
        //Constructor Injection
        public EmploySearchService(IEmployeeRepository repo)
        {
            this._repo = repo;
        }
        //public IEnumerable<Employee> Search(IFilter filter)
        //{
        //    return filter.Filter(this._repo.GetAll());
        //}
        public IEnumerable<Employee> Search(Func<Employee,bool> filter)
        {
            IEnumerable<Employee> employees = this._repo.GetAll();
            foreach(Employee emp in employees)
            {
                if (filter(emp))
                {
                    yield return emp;
                }
            }

        }
       
    }

    public class EntryPoint
    {
        //Pure Function  -> Parallel 
        //Output is Predicatble : Unit test friendly
        
        static bool  CheckIdValueEqaulsToE100(Employee source)
        {
            return source.ID == "E100";
        }
        static bool CheckIdValueEqaulsToE200(Employee source)
        {
            return source.ID == "E200";
        }
        static bool CheckNameEqaulsToTom(Employee source)
        {
            return source.Name == "TOM";
        }
        static void Main()
        {
            EmploySearchService _searchService = new EmploySearchService(new EmployeeInMemoryRepository());
          IEnumerable<Employee> result=  _searchService.Search(new Func<Employee, bool>(CheckIdValueEqaulsToE100));
            result = _searchService.Search(new Func<Employee, bool>(CheckIdValueEqaulsToE200));
            result = _searchService.Search(new Func<Employee, bool>(CheckNameEqaulsToTom));

        }
    }
}
