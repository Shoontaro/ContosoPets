using ContosoPets.Interfaces;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContosoPets.Services
{
    public class PetService : IProcessor
    {
        public async Task AddAnimal(Animal animals)
        {
            throw new NotImplementedException();
        }

        public async Task<Animal> GetAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Animal>> GetAnimals()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAnimal(Animal animals)
        {
            throw new NotImplementedException();
        }
    }
}
