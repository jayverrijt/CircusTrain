using CircusTrain.Enums;

namespace CircusTrain.Models
{
    public class Animal
    {
        public string Name { get; }
        public Diet Diet { get; }
        public Size Size { get; }
        public int Points => (int)Size;

        public Animal(string name, Diet diet, Size size)
        {
            Name = name;
            Diet = diet;
            Size = size;
        }

        public override string ToString()
        {
            return $"{Name} | {Diet} | {Size} ({Points} pts)";
        }
    }
}
