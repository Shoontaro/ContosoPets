using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets.Interfaces
{
    public interface IProcessor
    {
        Task AddAnimal(Animal animals);
        Task<Animal> GetAnimal(int id);
        Task RemoveAnimal(Animal animals);
        Task<List<Animal>> GetAnimals();
    }
}
