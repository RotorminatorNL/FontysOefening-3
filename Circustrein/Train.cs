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

        public int AnimalCount { get; private set; }

        public Train(int AnimalCount)
        {
            trainWagons = new List<Wagon>();
            totalSpace = 0;
            totalUsedSpace = 0;
            this.AnimalCount = AnimalCount;
        }

        public Train MakeTrainReady(List<Animal> circusAnimals)
        {
            circusAnimals = SortingList(circusAnimals);

            for (int i = 0; i < circusAnimals.Count; i++)
            {
                Wagon wagon = new Wagon(trainWagons.Count + 1);
                totalSpace += wagon.Space;

                Animal primaryAnimal = circusAnimals[i];
                wagon.AddAnimalToWagon(circusAnimals, primaryAnimal);
                totalUsedSpace += primaryAnimal.Weight;

                for (int j = 0; j < circusAnimals.Count; j++)
                {
                    Animal secondaryAnimal = circusAnimals[j];

                    if (wagon.EnoughSpace(secondaryAnimal))
                    {
                        if (secondaryAnimal.CompatibleWith(primaryAnimal))
                        {
                            wagon.AddAnimalToWagon(circusAnimals, secondaryAnimal);
                            totalUsedSpace += secondaryAnimal.Weight;
                            j = -1;
                        }
                    }
                }

                trainWagons.Add(wagon);
                i = -1;
            }

            return this;
        }

        public static List<Animal> SortingList(List<Animal> unSortedAnimalList)
        {
            List<Animal> sortedAnimalList = new List<Animal>();
            Animal highestPriorityAnimal = null;

            for (int i = 0; i < unSortedAnimalList.Count; i++)
            {
                if (highestPriorityAnimal == null)
                {
                    highestPriorityAnimal = unSortedAnimalList[i];
                }
                else if (Convert.ToInt32(highestPriorityAnimal.Type) < Convert.ToInt32(unSortedAnimalList[i].Type))
                {
                    highestPriorityAnimal = unSortedAnimalList[i];
                }
                else if (highestPriorityAnimal.Weight < unSortedAnimalList[i].Weight)
                {
                    if (unSortedAnimalList[i].Type == Types.vleeseter)
                    {
                        highestPriorityAnimal = unSortedAnimalList[i];
                    }
                    else if (highestPriorityAnimal.Type == Types.planteter)
                    {
                        highestPriorityAnimal = unSortedAnimalList[i];
                    }
                    else
                    {
                        // do nothing
                    }
                }
                else
                {
                    // do nothing
                }

                if (unSortedAnimalList.Count != 0 && unSortedAnimalList.Count <= i + 1)
                {
                    sortedAnimalList.Add(highestPriorityAnimal);
                    unSortedAnimalList.Remove(highestPriorityAnimal);
                    highestPriorityAnimal = null;
                    i = -1;
                }
            }

            return sortedAnimalList;
        }

        public List<Wagon> GetTrainWagons()
        {
            List<Wagon> wagons = new List<Wagon>();
            foreach (Wagon wagon in trainWagons)
                wagons.Add(wagon);
            return wagons;
        }

        public override string ToString()
        {
            return $"{totalUsedSpace} / {totalSpace}";
        }
    }
}
