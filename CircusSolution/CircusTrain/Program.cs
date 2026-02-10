using System;
using CircusTrain.Ui;

namespace CircusTrain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                ShowMenu();

                Console.Write("\nChoose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AnimalUi.RegisterAnimal();
                        break;

                    case "2":
                        AnimalUi.ShowAnimals();
                        break;

                    case "3":
                        TrainUI.RegisterTrain();
                        break;

                    case "4":
                        TrainUI.AssignAnimalToTrain();
                        break;

                    case "0":
                        isRunning = false;
                        ExitApplication();
                        break;

                    default:
                        ShowInvalidOption();
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Welcome to Circus Train!");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1) Register a new animal");
            Console.WriteLine("2) Show all animals");
            Console.WriteLine("3) Register a new train");
            Console.WriteLine("4) Assign an animal to a train");
            Console.WriteLine("0) Exit");
        }

        private static void ShowInvalidOption()
        {
            Console.WriteLine("\n Invalid option.");
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
        }

        private static void ExitApplication()
        {
            Console.WriteLine("\nGoodbye");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
