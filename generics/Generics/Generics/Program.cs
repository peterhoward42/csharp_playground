using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
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
            // Make a generic container to which you can Add() things, and when you do,
            // it returns how many items are present. Then exercise it for Strings.

            var myContainer = new CountingContainer<string>();
            myContainer.Add("hello");
            int storedCount = myContainer.Add("world");
            System.Diagnostics.Debug.Print("Numbe stored is: {0}", storedCount);
        }
    }

    public class CountingContainer<T>
    {
        ICollection<T> storage;

        public CountingContainer()
        {
            storage = new LinkedList<T>();
        }

        public int Add(T item)
        {
            storage.Add(item);
            return storage.Count;
        }
    }
    
}
