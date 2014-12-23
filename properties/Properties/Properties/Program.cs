using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            new App().run();
        }
    }


    class App
    {
        public void run()
        {
            // Access a thing's property
            new ThingWithProperty().Age = 42;
        }
    }

    // The class ThingWithProperty demonstrates how exposing a field as a property,
    // allows the caller to use field access syntax, but under the hood a 
    // setter method is called, and includes a side effect.
    public class ThingWithProperty
    {
        private int _age;
        private int _setCounter = 0;

        public int Age
        {
            set
            {
                _setCounter++;
                _age = value;
            }
            get{return _age;}
        }
    }

}
