using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories.Contracts
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public IRider GetByName(string name)
            => this.riders.FirstOrDefault(r => r.Name == name);

        public IReadOnlyCollection<IRider> GetAll()
            => this.riders.ToList();

        public void Add(IRider rider)
            => this.riders.Remove(rider);

        public bool Remove(IRider rider)
            => this.riders.Remove(rider);
    }
}