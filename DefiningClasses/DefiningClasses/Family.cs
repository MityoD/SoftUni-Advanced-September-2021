using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public List<Person> members = new List<Person>();
        public void AddMember(string name, int age)
        {
            Person newPerson = new Person(name, age);
            members.Add(newPerson);
        }
        public Person GetOldestMember()
        {
            Person oldestMember = members.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
             
        }
    }
}
