using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace jsonQuery
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isActive { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string eyeColor { get; set; }
        public List<string> friends { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("code_test.json");
            var people = JsonConvert.DeserializeObject<List<Person>>(json);
            
            // Query 1
            var allPeople = from p in people
                            orderby p.age descending, p.lastName ascending, p.firstName ascending
                            select p;

            Console.WriteLine("### Answer of Query 1 ###");
            foreach(var row in allPeople)
            {
                Console.WriteLine(row.age + " | " + row.lastName + "," + row.firstName + " | " + row.eyeColor + " | " + row.gender);
            }

            //Query 2
            var countPeople = (from p in allPeople
                               select p).Count();
            Console.WriteLine("\n### Answer of Query 2 ###");
            Console.WriteLine(countPeople);

            //Query 3
            var activeMen = from p in people
                            where p.isActive == true && p.eyeColor == "blue" && p.age > 30
                            orderby p.age descending, p.lastName ascending, p.firstName ascending
                            select p;

            Console.WriteLine("\n### Answer of Query 3 ###");
            foreach(var row in activeMen)
            {
                Console.WriteLine(row.age + " | " + row.lastName + "," + row.firstName + " | " + row.eyeColor + " | " + row.gender);
            }

            //Query 4
            var countActiveMen = (from p in activeMen
                                select p).Count();
            Console.WriteLine("\n### Answer of Query 4 ###");
            Console.WriteLine(countActiveMen);

            //Query 5
            var friendLessThree = from p in people
                                  where p.friends.Count() < 3
                                  select p;
            Console.WriteLine("\n### Answer of Query 5 ###");
            foreach (var row in friendLessThree)
            {
                Console.WriteLine(row.age + " | " + row.lastName + "," + row.firstName + " | " + row.eyeColor + " | " + row.gender + " | " + row.friends.Count());
            }

        }
    }
}
