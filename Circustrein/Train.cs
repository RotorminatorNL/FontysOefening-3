using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Train
    {
        private List<Wagon> trainWagons;
        private int totalSpace;
        private int totalUsedSpace;
        private int animalCount;

        public Train(int AnimalCount)
        {
            trainWagons = new List<Wagon>();
            totalSpace = 0;
            totalUsedSpace = 0;
            animalCount = AnimalCount;
        }

        public void MakeTrainReady(List<Animal> circusAnimals)
        {
            // vul wagon met dieren
            // wagon vol add wagon aan trein
            // nieuw wagon vullen
            // trein klaar wanneer alle dieren in een wagon zijn

            circusAnimals = SortList(circusAnimals);
        }

        private List<Animal> SortList(List<Animal> circusAnimals)
        {
            List<Animal> sortedList = new List<Animal>();
            while (circusAnimals.Count != 0)
            {
                Animal animal = null;
                foreach (Animal a in circusAnimals)
                {
                    if (animal == null)
                        animal = a;
                    else if (animal.Size < a.Size || a.Type == Types.vleeseter)
                        animal = a;
                    else if (animal.Size < a.Size && !MeatEaterPresent(circusAnimals))
                        animal = a;
                }
                sortedList.Add(animal);
                circusAnimals.Remove(animal);
            }
            return sortedList;
        }

        private bool MeatEaterPresent(List<Animal> animals)
        {
            foreach (Animal a in animals)
            {
                if (a.Type == Types.vleeseter)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{totalUsedSpace} / {totalSpace}";
        }
    }
}
