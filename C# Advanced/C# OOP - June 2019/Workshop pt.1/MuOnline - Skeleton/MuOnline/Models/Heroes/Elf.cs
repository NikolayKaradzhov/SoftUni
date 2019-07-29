namespace MuOnline.Models.Heroes
{
    public class Elf : Hero
    {
        public Elf(string username)
            : base (username, strength, agility, stamina, energy)
        {
        }

        private const int strength = 15;
        private const int agility = 30;
        private const int stamina = 60;
        private const int energy = 80;
    }
}
