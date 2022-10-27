using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> OpinionPool = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person newPerson = new Person(input[0], int.Parse(input[1]));
                OpinionPool.Add(newPerson);
            }
            foreach (var person in OpinionPool.OrderBy(x => x.Name))
            {
                if (person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
            
        }
        public static void EditFamilyMembers()
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] values = Console.ReadLine().Split();
                string name = values[0];
                int age = int.Parse(values[1]);
                family.AddMember(name, age);
            }
            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");    
        }
        public static void EnterNewPerson()
        {
            Person newPerson1 = new Person();
            Console.WriteLine(newPerson1.Name);
            Console.WriteLine(newPerson1.Age);
            Person newPerson2 = new Person(12);
            Console.WriteLine(newPerson2.Name);
            Console.WriteLine(newPerson2.Age);
            Person newPerson3 = new Person("Peter", 13);
            Console.WriteLine(newPerson3.Name);
            Console.WriteLine(newPerson3.Age);
        }
    }
}
