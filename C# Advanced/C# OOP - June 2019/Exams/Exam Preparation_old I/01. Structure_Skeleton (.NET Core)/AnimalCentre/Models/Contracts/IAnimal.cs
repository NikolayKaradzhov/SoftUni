namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        int Happiness { get; set; }

        int Energy { get; set; }

        int ProcedureTime { get; }

        string Owner { get; }

        bool IsAdopt { get; }

        bool IsChipped { get; set; }

        bool IsVaccinated { get; }
    }
}