using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Core.AnimalFactory;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IAnimalFactory animalFactory;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory.AnimalFactory();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            return $"Animal registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Vaccinate(string name, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Fitness(string name, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Play(string name, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string DentalCare(string name, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string NailTrim(string name, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Adopt(string animalName, string owner)
        {
            throw new NotImplementedException();
        }

        public string History(string type)
        {
            throw new NotImplementedException();
        }

    }
}
