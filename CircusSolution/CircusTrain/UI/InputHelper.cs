using System;
using CircusTrain.Enums;
using CircusTrain.Models;

namespace CircusTrain.Ui
{
    public static class InputHelper
    {
        public static Diet ReadDiet()
        {
            while (true)
            {
                Console.Write("Diet (1 = Carnivore, 2 = Herbivore): ");
                string input = Console.ReadLine();

                if (input == "1") return Diet.Carnivore;
                if (input == "2") return Diet.Herbivore;

                Console.WriteLine("Invalid input, try again.\n");
            }
        }

        public static Size ReadSize()
        {
            while (true)
            {
                Console.Write("Size (1 = Small, 2 = Medium, 3 = Large): ");
                string input = Console.ReadLine();

                if (input == "1") return Size.Small;
                if (input == "2") return Size.Medium;
                if (input == "3") return Size.Large;

                Console.WriteLine("Invalid input, try again.\n");
            }
        }
        public static string ReadAnimalName()
        {
            while (true)
            {
                Console.WriteLine("Choose animal type:");

                for (int i = 0; i < AnimalTypes.All.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {AnimalTypes.All[i]}");
                }

                Console.Write("Selection: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) &&
                    choice >= 1 &&
                    choice <= AnimalTypes.All.Count)
                {
                    return AnimalTypes.All[choice - 1];
                }

                Console.WriteLine("\n❌ Invalid selection. Please choose a number from the list.\n");
            }
        }
         public static AnimalDefinition ReadAnimalDefinitionWithOther()
         {
                while (true)
                {
                    Console.WriteLine("Choose animal type:");

                    for (int i = 0; i < AnimalCatalog.All.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {AnimalCatalog.All[i]}");
                    }

                    Console.WriteLine($"{AnimalCatalog.All.Count + 1}) Other (custom animal)");
                    Console.Write("Selection: ");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int choice))
                    {
                        // Existing animal
                        if (choice >= 1 && choice <= AnimalCatalog.All.Count)
                        {
                            return AnimalCatalog.All[choice - 1];
                        }

                        // Other
                        if (choice == AnimalCatalog.All.Count + 1)
                        {
                            return ReadCustomAnimal();
                        }
                    }

                    Console.WriteLine("\n❌ Invalid selection.\n");
                }
         }

         private static AnimalDefinition ReadCustomAnimal()
         {
             string name;
             while (true)
             {
                 Console.Write("Enter animal name: ");
                 name = Console.ReadLine();

                 if (!string.IsNullOrWhiteSpace(name))
                     break;

                 Console.WriteLine("❌ Animal name cannot be empty.");
             }

             Diet diet = ReadDiet();

             return new AnimalDefinition(name.Trim(), diet);
         }

    }

}