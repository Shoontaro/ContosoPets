using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CommandLine;

namespace ContosoPets
{
    public class Commands
    {
        private List<Animal> ourAnimals = new List<Animal>();

        public Commands(List<Animal> ourAnimals)
        { 
        this.ourAnimals = ourAnimals;
        }

        public void Comm() 
        {
            string command = View.ReadLine();

            Command list = new("list");
            list.SetAction(parseResult => {
                BL.ListAnimals(ourAnimals);
            });

            Command add = new("add");
            add.SetAction(parseResult => {
                BL.AddAnimal(new Animal(Types.cat, 1, "ok", "good girl", "Tosya"), ourAnimals);
            });

            RootCommand rootCommand = new("Todo проект с использованием System.CommandLine")
            { 
            list,
            add
            };

            rootCommand.Parse(command).Invoke();
        }
    }
}
