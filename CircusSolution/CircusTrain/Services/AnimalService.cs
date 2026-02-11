using CircusTrain.Models;

namespace CircusTrain.Services
{
    public static class AnimalService
    {
        private static readonly List<Animal> animals = new();

        public static void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public static List<Animal> GetAnimals()
        {
            return animals;
        }

        public static bool HasAnimals()
        {
            return animals.Count > 0;
        }

        public static void Clear()
        {
            animals.Clear();
        }
    }
}