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

        public IProvider Provider { get; set; }
        public PetService(IProvider provider)
        { 
            Provider = provider;
        }

        public async Task AddAnimal(Animal animals)
        {
            throw new NotImplementedException();
        }

        public async Task<Animal> GetAnimal(int id)
        {
            List<Animal> animals = await Provider.LoadAnimalsAsync();
            Animal animal = animals.Find(x => x.Id == id)??new Animal();
            return animal;
        }

        public async Task<List<Animal>> GetAnimals()
        {
            return await Provider.LoadAnimalsAsync();
        }

        public async Task RemoveAnimal(Animal animals)
        {
            List<Animal> animals = await Provider.LoadAnimalsAsync();
        }
    }
}
