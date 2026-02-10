using CircusTrain.Enums;
using CircusTrain.Models;

namespace CircusTrain.Services;

public class TrainBuilderService
{
    private const int MaxExperimentalWagons = 4;

    public void BuildTrain(Train train, List<Animal> animals)
    {
        // Sorteer: eerst carnivoren, groot → klein
        var orderedAnimals = animals
            .OrderByDescending(a => a.Diet == Diet.Carnivore)
            .ThenByDescending(a => a.Size)
            .ToList();

        foreach (var animal in orderedAnimals)
        {
            if (!TryPlaceInNormalWagon(train, animal))
            {
                if (!TryPlaceInExperimentalWagon(train, animal))
                {
                    var newWagon = new Wagon();
                    newWagon.AddAnimal(animal);
                    train.Wagons.Add(newWagon);
                }
            }
        }
    }

    private bool TryPlaceInNormalWagon(Train train, Animal animal)
    {
        foreach (var wagon in train.Wagons.OfType<Wagon>())
        {
            if (wagon.CanAddAnimal(animal))
            {
                wagon.AddAnimal(animal);
                return true;
            }
        }
        return false;
    }

    private bool TryPlaceInExperimentalWagon(Train train, Animal animal)
    {
        var experimentalCount = train.Wagons.OfType<ExperimentalWagon>().Count();
        if (experimentalCount >= MaxExperimentalWagons)
            return false;

        var wagon = new ExperimentalWagon();
        wagon.AddAnimal(animal);
        train.Wagons.Add(wagon);
        return true;
    }
}
