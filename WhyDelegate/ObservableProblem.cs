using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyDelegate
{
    public class SearchWindow
    {
        Button _searchButton = new Button();
        TextBox _textBox = new TextBox();

        //Imitation Of UI Button Click
        public void SimulateButtonClick()
        {
            _searchButton.OnClick();

        }

    }
    //Observable- Notify
    public class Button
    {
        public void OnClick()
        {

        }

    }
    public class TextBox
    {
        public void Clear()
        {
            Console.WriteLine("Clearing TextBox Content !!!! .....Done");
        }
    }
    public class ObservableProblem
    {
        static void Main()
        {

            SearchWindow _window = new SearchWindow();
            while (true)
            {
                Console.WriteLine("Press Any Key To trigger Button Click");
                Console.ReadKey();
                _window.SimulateButtonClick();
            }
        }
    }

    public enum SocketStatus
    {
        OPEN,CLOSED

    }

    //Subject
    //Event Driven Programming 
    public class Socket
    {
        SocketStatus status;
        public event  Action StatusChanged;//Event
        

        ////Subscribe for Notification
        //public void Add_StatusChanged(Action observer)
        //{
        //    this.StatusChanged += observer;
        //}
        ////UnSubscribe
        //public void Remove_StatusChanged(Action observer)
        //{
        //    this.StatusChanged -= observer;
        //}
        public void Open() {
            status = SocketStatus.OPEN;
            this.NotifyAll();
        }
        public void Close() {
            status = SocketStatus.CLOSED;
            this.NotifyAll();
        }
        void NotifyAll()
        {
            if (this.StatusChanged != null)
            {
                //Raise An Event
                this.StatusChanged.Invoke();//MulitiCast....
            }
        }
    }

    //Observable 
    public class Application
    {
        Socket _socket = new Socket();
        public Application()
        {

            //SubScube
            //_socket.Add_StatusChanged(new Action(this.Update));
            _socket.StatusChanged += new Action(this.Update);
        }
        void Update()
        {
            Console.WriteLine("Socket Status Changed");
        }
        public void Connect() {
            _socket.Open();
        }
        public void DisConnect()
        {
            _socket.Close();

        }
    }
}
