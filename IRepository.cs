using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets
{
    interface IRepository
    {
        void AddAnimal(Animal animals);
        Animal GetAnimal(int id);
        void RemoveAnimal(Animal animals);
        List<Animal> GetAnimals();

    }
}
