namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDate;
            this.Id = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public string Id { get; set; }
    }
}