using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected ICollection<IAnimal> ProcedureHistory;
        
        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var animal in ProcedureHistory)
            {
                sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}