using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_App
{
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

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Peter", "Howard", 55);
            string output = JsonConvert.SerializeObject(person);
            Console.WriteLine("json out is: {0}", output);

            Person aNewPerson = JsonConvert.DeserializeObject<Person>(output);
            string reOutput = JsonConvert.SerializeObject(aNewPerson);
            Console.WriteLine("json re-out is: {0}", reOutput);
        }
    }
}
