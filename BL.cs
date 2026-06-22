using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets
{
    public class BL
    {
        public static void ListAnimals(List<Animal> animals) 
        {
            if (animals is List<Animal>)
            {
                View.ViewTable(animals);
            }
        }
    }
}
