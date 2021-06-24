using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewTask
{
    /*
     * C# is a static Language
     * Dynamic Language (JavaScript, Python , ....)
     *     Object obj=new Object();//Elastic 
     *     obj.Id=10;
     *     obj.getId();
     *     delete obj.Id;
     *     
     */
    public class DynamicCalculator : System.Dynamic.DynamicObject
    {
        Dictionary<string, System.Linq.Expressions.Expression<Func<int, int,int >>> _expressions = new Dictionary<string, Expression<Func<int, int,int >>>();

        public DynamicCalculator()
        {

            _expressions.Add("Add", (x, y) => x + y);
            _expressions.Add("Sub", (x, y) => x - y);
            _expressions.Add("Div", (x, y) => x / y);
            _expressions.Add("Mul", (x, y) => x * y);

        }
        //public void Invoke() { }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;

            if (_expressions.ContainsKey(binder.Name))
            {
               var expression= _expressions[binder.Name];
                
               result= expression.Compile().Invoke((int)args[0], (int)args[1]);
                return true;

            }
            return false;
        }

    }

    public class ElasticObject : DynamicObject
    {
        Dictionary<string, object> _stateBag = new Dictionary<string, object>();
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _stateBag[binder.Name] = value;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (_stateBag.ContainsKey(binder.Name))
            {
                result = _stateBag[binder.Name];
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Late Binding - Use Reflection (API to query Metadata)
            dynamic obj = new DynamicCalculator();
            //Expression
            Console.WriteLine(obj.Add(10, 20));
            Console.WriteLine(obj.Sub(10, 20));
            Console.WriteLine(obj.Mul(10, 20));

            dynamic customer = new ElasticObject();
            customer.Id = "C100";
            customer.Name = "Tom";
            customer.Age = 35;
            Console.WriteLine(customer.Id + " " + customer.Name + " " + customer.Age);

            dynamic employee= new ElasticObject();
            employee.Eid = "E100";
            employee.Name = "Hary";
            Console.WriteLine(employee.Id + " " + employee.Name);

        }
         

     
    }
}
