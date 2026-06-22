using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets
{

    public enum Types { 
    cat,
    dog
    }
    public class Animal
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("NAME")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("TYPE")]
        public Types AnimalType { get; set; }

        [DisplayName("AGE")]
        public int Age { get; set; }

        [DisplayName("PHYSICAL CONDITION")]
        public string PhysCondition { get; set; } = string.Empty;
        [DisplayName("PERSONALITY")]
        public string Personality { get; set; } = string.Empty;
        
        public Animal(Types type, int age, string phys, string personality, string name) 
        {
            AnimalType = type;
            Age = age;
            PhysCondition = phys;
            Personality = personality;
            Name = name;
        }

        public Animal(int id, Types animalType, int age, string physCondition, string personality, string name)
        {
            Id = id;
            AnimalType = animalType;
            Age = age;
            PhysCondition = physCondition;
            Personality = personality;
            Name = name;
        }

        public static List<Animal> Seeds()
        {
            return new List<Animal>() { 
                new Animal(0, Types.cat, 1, "great", "cute", "Tom"),
                new Animal(1, Types.dog, 2, "great", "cute", "Greg"),
                new Animal(2, Types.cat, 1, "great", "cute", "Ter"),
                new Animal(3, Types.dog, 1, "great", "cute", "Grem")
            };
        }
    }
}
