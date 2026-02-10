using CircusTrain.Enums;

namespace CircusTrain.Models
{
    public static class AnimalCatalog
    {
        public static readonly List<AnimalDefinition> All = new()
        {
            new("Leeuw", Diet.Carnivore),
            new("Tijger", Diet.Carnivore),
            new("Zebra", Diet.Herbivore),
            new("Aap", Diet.Herbivore),
            new("Hond", Diet.Herbivore),
            new("Kat", Diet.Carnivore),
            new("Olifant", Diet.Herbivore),
            new("Koe", Diet.Herbivore),
            new("Paard", Diet.Herbivore),
            new("Dolfijn", Diet.Carnivore),
        };
    }
}