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

        public async Task AddAnimal(Animal animal)
        {

            if (animal == null) {
                Console.WriteLine("Не введено животное");
                return;
            }

            List<Animal> animals = await Provider.LoadAnimalsAsync();
            animal.Id = animals.Count > 0 ? animals.Last().Id + 1 : 1;

            animals.Add(animal);

            await Provider.SaveAnimalsAsync(animals);
            
            Console.WriteLine($"Животное успешно добавлено! Id {animal.Id}");
        }

        public async Task<Animal> GetAnimal(int id)
        {
            List<Animal> animals = await Provider.LoadAnimalsAsync();
                            
            Animal? animal = animals.Find(x => x.Id == id);
            if (animal == null) {
                Console.WriteLine("Нет такого зверя");
                return new Animal();
            }
            return animal;
        }

        public async Task<List<Animal>> GetAnimals()
        {
            return await Provider.LoadAnimalsAsync();
        }

        public async Task RemoveAnimal(Animal animal)
        {
            List<Animal> animals = await Provider.LoadAnimalsAsync();

            if (!animals.Contains(animal))
            {
                Console.WriteLine("Нет такого зверя");
                return;
            }

            animals.Remove(animal);
            await Provider.SaveAnimalsAsync(animals);
            Console.WriteLine("Животное удалено");
        }
    }
}
