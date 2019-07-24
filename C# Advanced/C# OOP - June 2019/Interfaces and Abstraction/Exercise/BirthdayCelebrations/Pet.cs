namespace FoodShortage
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthDate;

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }

        public string Name
        {
            get => this.name;

            private set => this.name = value;
        }

        public string Birthdate
        {
            get => this.birthDate;

            private set => this.birthDate = value;
        }
    }
}