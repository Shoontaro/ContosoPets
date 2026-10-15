using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ContosoPets.Repos
{
    public class JsonFiles 
    {
        private readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "pets.json");

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };


        public async Task<List<Animal>> LoadTasksAsync()
        {
            if (!File.Exists(FilePath)) return new List<Animal>();

            using FileStream openStream = File.OpenRead(FilePath);

            var result = await JsonSerializer.DeserializeAsync<List<Animal>>(openStream, Options);

            return result ?? new List<Animal>();
    }

        public async Task SaveTasksAsync(List<Animal> todos)
        {
            using FileStream createStream = File.Create(FilePath);

            await JsonSerializer.SerializeAsync(createStream, todos, Options);
        }

    }
}
