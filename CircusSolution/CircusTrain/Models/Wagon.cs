using System.Collections.Generic;
using CircusTrain.Enums;
namespace CircusTrain.Models;

public class Wagon
{
    protected List<Animal> animals = new();

    public virtual bool CanAddAnimal(Animal animal)
    {
        if (CurrentPoints + animal.Points > 10)
            return false;

        foreach (var existing in animals)
        {
            if (existing.Diet == Diet.Carnivore &&
                existing.Size >= animal.Size)
                return false;

            if (animal.Diet == Diet.Carnivore &&
                animal.Size >= existing.Size)
                return false;
        }

        return true;
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public int CurrentPoints => animals.Sum(a => a.Points);

    public IReadOnlyList<Animal> Animals => animals;
}
