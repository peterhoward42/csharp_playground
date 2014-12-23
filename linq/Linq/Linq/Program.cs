using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
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
            // First baby steps

            int[] aList = {1,2,3,4,5,6,7,8,9};
            IEnumerable<int> iterable = (from i in aList where ((i % 2) == 0) select i);
            foreach (int i in iterable)
            {
                System.Diagnostics.Debug.Print(i.ToString());
            }

            // Build in sort ordering
            iterable = (from i in aList where ((i % 2) == 0) orderby i descending select i );
            foreach (int i in iterable)
            {
                System.Diagnostics.Debug.Print(i.ToString());
            }
        }
    }
}
