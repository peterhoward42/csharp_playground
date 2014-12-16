using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;

// Parse a file that contains lines like this:
//      peter   howard  55
//      alison  howard  49

namespace RegexParse
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Error - specify file to open as command line argument");
                return;
            }
            new App().run(args[0]);
        }
    }

    class Person
    {
        public string firstName;
        public string secondName;
        public int age;

        public Person(string firstName, string secondName, int age)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.age = age;
        }
    }

    class App
    {
        public void run(String fileToRead)
        {

            try
            {
                var inputStream = new System.IO.StreamReader(fileToRead);
                var people = new List<Person>();
                String aLine;
                while ((aLine = inputStream.ReadLine()) != null)
                {
                    var regex = new Regex(@"(\w+)\s+(\w+)\s+(\d+)");

                    int[] groupNumbers = regex.GetGroupNumbers();
                    var m = regex.Match(aLine);
                    if (m.Success == false)
                    {
                        Console.WriteLine("Error - this line cannot be parsed: <{0}>", aLine);
                        return;
                    }
                    var person = new Person(m.Groups[1].Value, m.Groups[2].Value, Int32.Parse(m.Groups[3].Value));
                    people.Add(person);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Got IO Exception for this filename: <{0}>", e.ToString());
                return;
            }
        }
    }
}
