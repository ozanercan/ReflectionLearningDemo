using ReflectionLearning.Classes;
using System;
using System.Reflection;

namespace ReflectionLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Id = 1,
                FirstName = "Ozan",
                LastName = "ERCAN"
            };
            Random r = new Random();

            //GetProperties(person);
            //GetMethods(person);
            //SetId(person, r);
            //GetFullNameMethod(person);

            Console.ReadKey();
        }

        private static void GetFullNameMethod(Person person)
        {
            var x = person.GetType().GetMethods();

            foreach (var item in x)
            {
                if (item.Name.Equals("GetFullName"))
                {
                    var s = item.Invoke(person, null);
                    Console.WriteLine(s);
                }
            }
        }

        private static void SetId(Person person, Random r)
        {
            var x = person.GetType().GetProperties();
            foreach (var item in x)
            {
                if (item.Name.Equals("Id"))
                    item.SetValue(person, r.Next(1000, 999999));
            }

            foreach (var item in x)
                Console.WriteLine(item.GetValue(person));
        }

        private static void GetMethods(Person person)
        {
            var x = person.GetType().GetMethods();
            foreach (var item in x)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void GetProperties(Person person)
        {
            var x = person.GetType().GetProperties();

            foreach (var item in x)
            {
                Console.WriteLine(item.Name);
            }
        }
    }


}
namespace ReflectionLearning.Classes
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return string.Join(" ", FirstName, LastName);
        }
    }
}