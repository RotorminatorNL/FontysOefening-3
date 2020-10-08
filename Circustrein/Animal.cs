using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return $"{Size} {Type}";
        }
    }
}
