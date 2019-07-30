using System;
using System.Collections.Generic;
using System.Linq;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Repository
            => this.heroes.AsReadOnly();

        public void Add(IHero hero)
        {
            if (hero == null) 
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            this.heroes.Add(hero);
        }

        public bool Remove(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            bool isHeroRemoved = this.heroes.Remove(hero);

            return isHeroRemoved;
        }

        public IHero Get(string hero)
        {
            var targetHero = this.heroes.FirstOrDefault(h => ((IIdentifiable) h).Username == hero);

            if (targetHero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            return targetHero;
        }
    }
}
