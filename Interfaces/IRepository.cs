using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPets
{
    public interface IProvider
    {
        public Task<List<Animal>> LoadAnimalsAsync();

        public Task SaveAnimalsAsync(List<Animal> todos);

    }
}
