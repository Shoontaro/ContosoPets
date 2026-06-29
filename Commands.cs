using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                Command update = new("update") { 
                id, 
                name, 
                age,
                condition,
                personality
                };
                update.Aliases.Add("change");
                update.SetAction(parseResult => {
                    int animalId = parseResult.GetValue(id);
                    if (ourAnimals.Any(v => v.Id == animalId))
                    {
                        Animal animal = ourAnimals?.Find(v => v.Id == animalId);

                        if (parseResult.Tokens.Any(v => v.Value == "--age" || v.Value == "-a"))
                        {
                            animal.ChangeAge(parseResult.GetValue(age));
                        }
                        if (parseResult.Tokens.Any(v => v.Value == "--name" || v.Value == "-n"))
                        {
                            animal.ChangeName(parseResult.GetValue(name));
                        }
                        if (parseResult.Tokens.Any(v => v.Value == "--condition" || v.Value == "-c"))
                        {
                            animal.ChangeCondition(parseResult.GetValue(condition));
                        }
                        if (parseResult.Tokens.Any(v => v.Value == "--personality" || v.Value == "-p"))
                        {
                            animal.ChangePersonality(parseResult.GetValue(personality));
                        }
                    }

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
            add,
            update
            };

                rootCommand.Parse(command).Invoke();
            }
        }
    }
}
