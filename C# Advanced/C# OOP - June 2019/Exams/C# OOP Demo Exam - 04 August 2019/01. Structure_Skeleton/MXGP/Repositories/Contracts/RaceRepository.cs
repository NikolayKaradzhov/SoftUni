using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IRace GetByName(string raceName)
            => this.races.FirstOrDefault(r => r.Name == raceName);

        public IReadOnlyCollection<IRace> GetAll()
            => this.races.ToList();

        public void Add(IRace race)
            => this.races.Remove(race);

        public bool Remove(IRace race)
            => this.races.Remove(race);
    }
}