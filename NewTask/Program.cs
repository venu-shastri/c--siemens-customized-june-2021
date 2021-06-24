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
        static void Main_old(string[] args)
        {
            //Late Binding - Use Reflection (API to query Metadata)
            dynamic obj = new DynamicCalculator();
            //Object obj=new DynamicCalculator();
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
            Console.WriteLine(employee.Eid + " " + employee.Name);

        }

        static void Main()
        {
            CSVAsEnumerable _provider = new CSVAsEnumerable() { FilePath = "..//..//Employee.csv" };
           dynamic resultline= _provider.Lines.Where((dynamic line) => { return line.ID == "EMP100"; }).FirstOrDefault();
            Console.WriteLine(resultline.NAME.ToString() +","+resultline.AGE+" ,"+resultline.LOCATION);

            resultline = _provider.Lines.Where((dynamic line) => { return line.LOCATION == "BLR"; }).ToList();
            foreach (dynamic _line in resultline)
            {
                // Console.WriteLine(_line.ID.ToString() + "," + _line.NAME.ToString() + "," + _line.AGE + " ," + _line.LOCATION);
                Console.WriteLine(
                    $"{_line.ID}," +
                    $"{_line.NAME}," +
                    $"{_line.AGE}," +
                    $"{_line.LOCATION}");

            }

        }
         

     
    }

    public class CsvLine :System.Dynamic.DynamicObject{

        List<string> headerContent = new List<string>();
        List<string> lineContent = new List<string>();
        public CsvLine(string header,string line)
        {
            this.headerContent = header.Split(',').ToList();
            this.lineContent = line.Split(',').ToList();
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            int index = headerContent.IndexOf(binder.Name);
            if(index != -1)
            {
                result = this.lineContent[index];
                return true;
            }
            return false;
        }

    }


    public class CSVAsEnumerable
    {
        public string FilePath { get; set; }

        public IEnumerable<CsvLine> Lines
        {
            get
            {
                return GetAllLines();
            }

        }
        List<CsvLine> GetAllLines()
        {
            System.IO.StreamReader _reader = new System.IO.StreamReader(this.FilePath);
           string header= _reader.ReadLine();
            List<CsvLine> _csvLines = new List<CsvLine>();
            while (!_reader.EndOfStream)
            {
               string line= _reader.ReadLine();
                CsvLine _lineItem = new CsvLine(header, line);
                _csvLines.Add(_lineItem);
            }
            return _csvLines;
                

        }
    }

    void Code(dynamic arg)
    {

        int x = 10;
        var y=20;
        dynamic z;
        object a;
        z.

    }
    
}
