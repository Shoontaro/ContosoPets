using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public static void AddAnimal(Animal animal, List<Animal> data) 
        { //сделать генериком
            if (animal is Animal) { 
                animal.Id = data.Count;
                data.Add(animal);

                View.Correct($"{animal.Name} added");
            }
        }
        public static void UpdateAge(int id, int age, List<Animal> data) {
            if (data.Any(v => v.Id == id))
            {
                Animal oldOne = data.Find(v => v.Id == id);

                oldOne.Age = age;
            }
            else
            {
                View.WriteLine("wrong id");
            }
        }
        public static void UpdateAnimal(int id, Animal animal, List<Animal> data) {
            if (animal is Animal && data.Any(v => v.Id == id))
            {
                Animal oldOne = data.Find(v => v.Id == id);

                oldOne.Personality = string.IsNullOrEmpty(animal.Personality) ? oldOne.Personality : animal.Personality;
            }
            else {
                View.WriteLine("Error");
            }
        }
    }
}
