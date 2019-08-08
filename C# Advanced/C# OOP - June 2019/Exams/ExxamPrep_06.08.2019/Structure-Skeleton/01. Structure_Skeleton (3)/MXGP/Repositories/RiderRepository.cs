﻿using System;
using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public IRider GetByName(string name)
            => this.riders.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRider> GetAll()
            => this.riders.ToList();

        public void Add(IRider model)
            => this.riders.Add(model);

        public bool Remove(IRider model)
            => this.riders.Remove(model);
    }
}