using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private IList<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models { get; }

        public void Add(IGun model)
        {
            if (!this.guns.Any(g => g.Name == model.Name))
            {
                guns.Add(model);
            }
        }

        public bool Remove(IGun model)
        {
            if (model == null)
            {
                return false;
            }

            this.guns.Remove(model);

            return true;
        }

        public IGun Find(string name)
        {
            var gun = this.guns.FirstOrDefault(g => g.Name == name);

            return gun;
        }
    }
}