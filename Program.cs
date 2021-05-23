using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app12
{
    public delegate void PropertyEventHandler(object sender, PropertyEventArgs e);
    public interface IPropertyChanged
    {
        event PropertyEventHandler PropertyChanged;
    }

    public class PropertyEventArgs
    {
        public PropertyEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public class Number : IPropertyChanged
    {
        public event PropertyEventHandler PropertyChanged;
        private int myVar;

        public Number(int myProperty)
        {
            MyProperty = myProperty;
        }
        public Number()
        {
            myVar = 0;
        }

        public int MyProperty
        {
            get { return myVar; }
            set 
            { 
                myVar = value;
                PropertyChanged.Invoke(this, new PropertyEventArgs($"Property has been changed to {value}!"));
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Number a = new Number();
            a.PropertyChanged += SendMessage;
            a.MyProperty = 5;
        }
        static void SendMessage(object sender, PropertyEventArgs e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
}
