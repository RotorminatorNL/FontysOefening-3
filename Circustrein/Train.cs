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
        private readonly List<Wagon> trainWagons;
        private readonly List<Animal> CircusAnimals;
        private int totalSpace;
        private int totalUsedSpace;

        public int AnimalCount { get; }

        public Train(List<Animal> circusAnimals)
        {
            CircusAnimals = circusAnimals;

            trainWagons = new List<Wagon>();
            totalSpace = 0;
            totalUsedSpace = 0;
            AnimalCount = CircusAnimals.Count;

            CircusAnimals = SortingList();

            MakeTrainReady();
        }

        private void MakeTrainReady()
        {
            if (CircusAnimals.Count != 0)
            {
                trainWagons.Add(new Wagon(trainWagons.Count + 1));

                for (int i = 0; i < trainWagons.Count; i++)
                {
                    bool addedAnimalSuccesfully = false;
                    if (trainWagons[i].AddAnimalToWagon(CircusAnimals[0]))
                    {
                        totalUsedSpace += Convert.ToInt32(CircusAnimals[0].Size);
                        CircusAnimals.Remove(CircusAnimals[0]);
                        addedAnimalSuccesfully = true;
                    }

                    if (!addedAnimalSuccesfully && !trainWagons[i].AddAnimalToWagon(CircusAnimals[0]) && trainWagons.Count == i + 1)
                        trainWagons.Add(new Wagon(trainWagons.Count + 1));

                    if (CircusAnimals.Count != 0 && trainWagons.Count == i + 1)
                        i = -1;

                    totalSpace = trainWagons.Count * trainWagons[0].Space;
                }
            }
        }

        private List<Animal> SortingList()
        {
            List<Animal> sortedAnimalList = new List<Animal>();
            Animal highestPriorityAnimal = null;

            for (int i = 0; i < CircusAnimals.Count; i++)
            {
                if (highestPriorityAnimal == null)
                {
                    highestPriorityAnimal = CircusAnimals[i];
                }
                else if (Convert.ToInt32(highestPriorityAnimal.Type) < Convert.ToInt32(CircusAnimals[i].Type))
                {
                    highestPriorityAnimal = CircusAnimals[i];
                }
                else if (Convert.ToInt32(highestPriorityAnimal.Size) < Convert.ToInt32(CircusAnimals[i].Size))
                {
                    if (CircusAnimals[i].Type == Types.vleeseter)
                    {
                        highestPriorityAnimal = CircusAnimals[i];
                    }
                    else if (highestPriorityAnimal.Type == Types.planteter)
                    {
                        highestPriorityAnimal = CircusAnimals[i];
                    }
                }

                if (CircusAnimals.Count != 0 && CircusAnimals.Count <= i + 1)
                {
                    sortedAnimalList.Add(highestPriorityAnimal);
                    CircusAnimals.Remove(highestPriorityAnimal);
                    highestPriorityAnimal = null;
                    i = -1;
                }
            }

            return sortedAnimalList;
        }

        public IReadOnlyList<Wagon> GetTrainWagons()
        {
            return trainWagons.AsReadOnly();
        }

        public override string ToString()
        {
            return $"{totalUsedSpace} / {totalSpace}";
        }
    }
}
