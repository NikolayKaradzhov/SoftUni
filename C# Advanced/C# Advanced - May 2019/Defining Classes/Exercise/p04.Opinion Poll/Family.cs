using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }

        public void AddMember(Person person)
        {
            members.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = members.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPerson;
        }

        public List<Person> FilterPersonByAgeOver30()
        {
            List<Person> peopleOver30 = members
                .OrderBy(x => x.Name)
                .Where(x => x.Age > 30)
                .ToList();

            return peopleOver30;
        }
    }
}