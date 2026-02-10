using CircusTrain.Enums;
namespace CircusTrain.Models;

public class ExperimentalWagon : Wagon
{
    public override bool CanAddAnimal(Animal animal)
    {
        if (animals.Count >= 2)
            return false;

        if (animal.Size == Size.Large)
            return false;

        if (animals.Count == 1)
        {
            var existing = animals[0];

            if (existing.Size == Size.Large || animal.Size == Size.Large)
                return false;
        }

        return true;
    }
}
