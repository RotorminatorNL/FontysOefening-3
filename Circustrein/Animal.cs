namespace Circustrein
{
    public class Animal
    {
        public Sizes Size { get; private set; }
        public Types Type { get; private set; }
        public int Weight { get; private set; }

        public Animal(Sizes size, Types type, int weight)
        {
            Size = size;
            Type = type;
            Weight = weight;
        }

        public bool CompatibleWith(Animal animal)
        {
            if (Type == Types.vleeseter && animal.Type == Types.vleeseter)
            {
                return false;
            }
            else if (animal.Type == Types.vleeseter && animal.Weight >= Weight)
            {
                return false;
            }
            else if (Type == Types.vleeseter && Weight >= animal.Weight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return $"{Size} {Type}";
        }
    }
}
