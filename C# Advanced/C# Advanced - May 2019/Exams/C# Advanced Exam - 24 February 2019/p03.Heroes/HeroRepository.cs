using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            Hero heroName = heroes.FirstOrDefault(n => n.Name == name);

            if (heroes.Contains(heroName))
            {
                heroes.Remove(heroName);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            int highestStrengthHero = this.heroes.Max(s => s.Item.Strength);

            return this.heroes.FirstOrDefault(s => s.Item.Strength == highestStrengthHero);
        }

        public Hero GetHeroWithHighestAbility()
        {
            int highestAbilityHero = this.heroes.Max(a => a.Item.Ability);

            return this.heroes.FirstOrDefault(a => a.Item.Ability == highestAbilityHero);
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int highestIntelligenceHero = this.heroes.Max(i => i.Item.Intelligence);

            return this.heroes.FirstOrDefault(i => i.Item.Intelligence == highestIntelligenceHero);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Hero hero in heroes)
            {
                sb.AppendLine($"{hero}");
            }

            return sb.ToString();
        }
    }
}