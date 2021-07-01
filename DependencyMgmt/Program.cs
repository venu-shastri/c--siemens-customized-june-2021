using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyMgmt
{
    public class Drive {

        //Dependency
        ICommunicationInterface _interface;
        //Depenendency Injection {Constructor, Setter, Method)

        public Drive() { }
        public Drive(ICommunicationInterface _interface){
            this._interface = _interface;
            }
        //Setter Injection
        public ICommunicationInterface Interface
        {
            set { _interface = value; }
            get { return _interface; }
        }
    
    }
    public interface ICommunicationInterface
    {
        void TransferData();
    }
    public class USB : ICommunicationInterface
    {
        public void TransferData()
        {
            throw new NotImplementedException();
        }
    }
    public class ProfiCable : ICommunicationInterface
    {
        public void TransferData()
        {
            throw new NotImplementedException();
        }
    }
    public class ProfiBus : ICommunicationInterface
    {
        public void TransferData()
        {
            throw new NotImplementedException();
        }
    }
    public class PLC
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Drive g120 = new Drive(new ProfiCable()); //Injection By Hand

            //AutoWiring
          Drive _drive=  Infrastructure.GetService<Drive>();
        }
    }
}
