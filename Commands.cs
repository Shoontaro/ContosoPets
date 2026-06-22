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
        public static void Comm() 
        {
            string command = View.ReadLine();

            Command list = new("list");
            list.SetAction(parseResult => {
                BL.ListAnimals(Animal.Seeds());
            });

            RootCommand rootCommand = new("Todo проект с использованием System.CommandLine")
            { 
            list
            };

            rootCommand.Parse(command).Invoke();
        }
    }
}
