using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
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
        delegate double ArithmeticFn(double a, double b);

        public static double addFn(double a, double b)
        {
            return a + b;
        }

        public static double multFn(double a, double b)
        {
            return a * b;
        }

        public void run()
        {
            // We choose one of our two calculation functions (add, multiply) based
            // on the current time (millsecond) being odd or even

            ArithmeticFn add = addFn;
            ArithmeticFn multiply = multFn;
            var chosenFn = (DateTime.Now.Millisecond % 2 == 0) ? add: multiply;
            double result = chosenFn(1, 2);
            Console.WriteLine("Function chosen was: {0}, and result was: {1}", chosenFn, result);
        }
    }
}
