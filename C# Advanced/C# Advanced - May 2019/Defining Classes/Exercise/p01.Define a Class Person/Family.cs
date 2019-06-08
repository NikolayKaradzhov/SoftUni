using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> member = new List<Person>();

        public List<Person> Member
        {
            get
            {
                return this.member;
            }
            set
            {
                this.member = value;
            }
        }

        public void AddMember(Person person)
        {
            member.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = member.OrderByDescending(x => x.Age).FirstOrDefault();
            
            return oldestPerson;
        }
    }
}