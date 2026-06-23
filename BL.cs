using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets
{
    public class BL
    {
        public static void ListAnimals(List<Animal> animals) //сделать генериком
        {
            if (animals is List<Animal>)
            {
                View.ViewTable(animals);
            }
        }

        public static void AddAnimal(Animal animal, List<Animal> data) { //сделать генериком
            if (animal is Animal) { 
                animal.Id = data.Count;
                data.Add(animal);

                View.WriteLine($"{animal.Name} added");
            }
        }
    }
}
