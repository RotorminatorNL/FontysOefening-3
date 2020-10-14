using System;

namespace Circustrein
{
    public class Animal
    {
        public Sizes Size { get; private set; }
        public Types Type { get; private set; }

        public Animal(Sizes size, Types type)
        {
            Size = size;
            Type = type;
        }

        public bool CompatibleWith(Animal animal)
        {
            if (Type == Types.vleeseter && animal.Type == Types.vleeseter)
            {
                return false;
            }
            else if (Type == Types.vleeseter && Convert.ToInt32(Size) >= Convert.ToInt32(animal.Size))
            {
                return false;
            }
            else if (animal.Type == Types.vleeseter && Convert.ToInt32(animal.Size) >= Convert.ToInt32(Size))
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
