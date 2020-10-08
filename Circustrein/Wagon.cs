using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Wagon
    {
        private List<Animal> animalsInWagon;
        private readonly int space;
        private int usedSpace;

        public Wagon()
        {
            animalsInWagon = new List<Animal>();
            space = 10;
            usedSpace = 0;
        }

        public override string ToString()
        {
            return $"{usedSpace} / {space}";
        }
    }
}
