using CircusTrain.Enums;
using CircusTrain.Models;

namespace CircusTrain.Services
{
    public class TrainBuilderService
    {
        private const int MaxExperimentalWagons = 4;

        public void BuildTrain(Train train, List<Animal> animals)
        {
            train.Wagons.Clear();

            // Sorteer dieren:
            // 1. Carnivoren eerst (gevaarlijkst)
            // 2. Groot naar klein
            var orderedAnimals = animals
                .OrderByDescending(a => a.Diet == Diet.Carnivore)
                .ThenByDescending(a => a.Size)
                .ToList();

            foreach (var animal in orderedAnimals)
            {
                if (TryPlaceInExistingNormalWagon(train, animal))
                    continue;
                if (TryPlaceInExistingExperimentalWagon(train, animal))
                    continue;
                if (TryCreateNewExperimentalWagon(train, animal))
                    continue;
                var newWagon = new Wagon();
                newWagon.AddAnimal(animal);
                train.Wagons.Add(newWagon);
            }
        }

        private bool TryPlaceInExistingNormalWagon(Train train, Animal animal)
        {
            foreach (var wagon in train.Wagons
                     .Where(w => w is not ExperimentalWagon))
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    return true;
                }
            }

            return false;
        }

        private bool TryPlaceInExistingExperimentalWagon(Train train, Animal animal)
        {
            foreach (var wagon in train.Wagons.OfType<ExperimentalWagon>())
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    return true;
                }
            }

            return false;
        }

        private bool TryCreateNewExperimentalWagon(Train train, Animal animal)
        {
            // Experimental wagons mogen geen Large dieren bevatten
            if (animal.Size == Size.Large)
                return false;

            int experimentalCount = train.Wagons
                .OfType<ExperimentalWagon>()
                .Count();

            if (experimentalCount >= MaxExperimentalWagons)
                return false;

            var newWagon = new ExperimentalWagon();

            if (!newWagon.CanAddAnimal(animal))
                return false;

            newWagon.AddAnimal(animal);
            train.Wagons.Add(newWagon);

            return true;
        }
    }
}
