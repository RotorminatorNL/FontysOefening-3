using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Train
    {
        private List<Wagon> trainWagons;
        private int totalSpace;
        private int totalUsedSpace; 

        public Train()
        {
            trainWagons = new List<Wagon>();
            totalSpace = 0;
            totalUsedSpace = 0;
        }

        public override string ToString()
        {
            return $"{totalUsedSpace} / {totalSpace}";
        }
    }
}
