using CircusTrain.Enums;

namespace CircusTrain.Models
{
    public class AnimalDefinition
    {
        public string Name { get; }
        public Diet Diet { get; }

        public AnimalDefinition(string name, Diet diet)
        {
            Name = name;
            Diet = diet;
        }

        public override string ToString() => $"{Name} ({Diet})";
    }
}