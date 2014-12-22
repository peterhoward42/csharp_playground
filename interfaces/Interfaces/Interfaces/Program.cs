using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
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
        public interface ICanTellTheTime
        {
            void soTellTheTimeThen();
        }

        public void run()
        {
            // Have a method that demands an input parameter that satisfies
            // the 'can tell the time' interface and exercise it.

            ICanTellTheTime myTimeTeller = new FraudulentTimeTeller();

            this.exerciseATimeTeller(myTimeTeller);
        }

        void exerciseATimeTeller(ICanTellTheTime aTimeTeller)
        {
            aTimeTeller.soTellTheTimeThen();
        }
    }

    class FraudulentTimeTeller : App.ICanTellTheTime {

        public void soTellTheTimeThen()
        {
            Console.WriteLine("The time is 42 (I lied)");
        }
    }
}
