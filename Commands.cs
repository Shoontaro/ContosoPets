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
            while (true)
            {
                Console.WriteLine();
                string command = View.ReadLine();

                Argument<Types> type = new("type");
                Argument<int> id = new("id");

                Option<string> name = new(name: "--name", aliases: "-n");
                Option<int> age = new(name: "--age", aliases: "-a");
                Option<string> condition = new(name: "--condition", aliases: "-c");
                Option<string> personality = new(name: "--personality", aliases: "-p");

                Command list = new("list");
                list.SetAction(parseResult =>
                {
                    BL.ListAnimals(ourAnimals);
                });

                Command add = new("add") {
            type,
            name,
            age,
            condition,
            personality
            };
                add.SetAction(parseResult =>
                {
                    BL.AddAnimal(new Animal(parseResult.GetValue(type), parseResult.GetValue(age),
                        parseResult.GetValue(condition) ?? "unknown",
                        parseResult.GetValue(personality) ?? "unknown",
                        parseResult.GetValue(name) ?? "Noname"), ourAnimals);
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
}
