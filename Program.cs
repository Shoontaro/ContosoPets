using ContosoPets;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Contoso Pets! \n");

        List<Animal> ourAnimals = Animal.Seeds();

        Commands.Comm();
    }
}