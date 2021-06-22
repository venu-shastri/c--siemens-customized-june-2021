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
            Console.WriteLine("Clearing TextBox Content !!!! .....Done")
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
}
