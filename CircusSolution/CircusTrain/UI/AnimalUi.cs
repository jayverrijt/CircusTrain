using CircusTrain.Enums;
using CircusTrain.Models;
using CircusTrain.Services;

namespace CircusTrain.Ui
{
    public static class AnimalUi
    {
        public static void RegisterAnimal()
        {
            Console.Clear();
            Console.WriteLine("🐘 Register New Animal\n");

            var definition = InputHelper.ReadAnimalDefinitionWithOther();
            Size size = InputHelper.ReadSize();

            Animal animal = new Animal(
                definition.Name,
                definition.Diet,
                size
            );

            AnimalService.AddAnimal(animal);

            Console.WriteLine("\nAnimal registered:");
            Console.WriteLine(animal);

            Pause();
        }



        public static void ShowAnimals()
        {
            Console.Clear();
            Console.WriteLine("Registered Animals\n");

            var animals = AnimalService.GetAnimals();

            if (animals.Count == 0)
            {
                Console.WriteLine("No animals registered yet.");
            }
            else
            {
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {animals[i]}");
                }
            }

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}