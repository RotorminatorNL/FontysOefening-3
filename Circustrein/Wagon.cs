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

        public readonly int Space;
        public int UsedSpace { get; private set; }
        public int wagonID { get; private set; }

        public Wagon(int WagonID)
        {
            animalsInWagon = new List<Animal>();
            Space = 10;
            UsedSpace = 0;
            wagonID = WagonID;
        }

        public void AddAnimalToWagon(List<Animal> animals, Animal animal)
        {
            animalsInWagon.Add(animal);
            UsedSpace += animal.Weight;
            animals.Remove(animal);
        }

        public override string ToString()
        {
            return $"{UsedSpace} / {Space}";
        }
    }
}
