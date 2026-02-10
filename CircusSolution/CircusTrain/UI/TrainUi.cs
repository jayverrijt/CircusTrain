using CircusTrain.Models;
using CircusTrain.Services;

namespace CircusTrain.Ui
{
    public static class TrainUI
    {
        private static Train train;

        public static void RegisterTrain()
        {
            Console.Clear();
            Console.WriteLine("🚆 Create Train\n");

            train = new Train();

            Console.WriteLine("Train created successfully.");
            Pause();
        }

        public static void AssignAnimalToTrain()
        {
            Console.Clear();
            Console.WriteLine("Build Train With Animals\n");

            if (train == null)
            {
                Console.WriteLine("No train exists. Create a train first.");
                Pause();
                return;
            }

            var animals = AnimalService.GetAnimals();

            if (animals.Count == 0)
            {
                Console.WriteLine("No animals registered.");
                Pause();
                return;
            }

            TrainBuilderService builder = new TrainBuilderService();
            builder.BuildTrain(train, animals);

            ShowTrain();
        }

        private static void ShowTrain()
        {
            Console.Clear();
            Console.WriteLine("Train Composition\n");

            int wagonNumber = 1;

            foreach (var wagon in train.Wagons)
            {
                Console.WriteLine($"Wagon {wagonNumber++} ({wagon.CurrentPoints}/10 pts)");

                foreach (var animal in wagon.Animals)
                {
                    Console.WriteLine($"   - {animal}");
                }

                Console.WriteLine();
            }

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}