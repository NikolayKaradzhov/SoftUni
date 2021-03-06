﻿using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private IList<IGun> guns;

        public IReadOnlyCollection<IGun> Models { get; }

        public void Add(IGun model)
        {
            if (guns.Contains(model))
            {

            }

            this.guns.Add(model);
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