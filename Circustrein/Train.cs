using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            while (CircusAnimals.Count != 0)
            {
                bool addedAnimalSuccesfully = false;
                foreach (Wagon wagon in trainWagons)
                {
                    addedAnimalSuccesfully = wagon.AddAnimalToWagon(CircusAnimals[0]);
                    if (addedAnimalSuccesfully)
                    {
                        totalUsedSpace += Convert.ToInt32(CircusAnimals[0].Size);
                        CircusAnimals.Remove(CircusAnimals[0]);
                    }
                }

                if(!addedAnimalSuccesfully)
                    trainWagons.Add(new Wagon(trainWagons.Count + 1));

                totalSpace = trainWagons.Count * trainWagons[0].Space;
            }
        }

        private List<Animal> SortingList()
        {
            List<Animal> sortedAnimalList = new List<Animal>();
            Animal highestPriorityAnimal = null;

            while (CircusAnimals.Count != 0)
            {
                foreach (Animal animal in CircusAnimals)
                {
                    if (highestPriorityAnimal == null)
                    {
                        highestPriorityAnimal = animal;
                    }
                    else if (highestPriorityAnimal.Type < animal.Type)
                    {
                        highestPriorityAnimal = animal;
                    }
                    else if (highestPriorityAnimal.Size < animal.Size)
                    {
                        if (animal.Type == Types.vleeseter)
                        {
                            highestPriorityAnimal = animal;
                        }
                        else if (highestPriorityAnimal.Type == Types.planteter)
                        {
                            highestPriorityAnimal = animal;
                        }
                    }
                }

                sortedAnimalList.Add(highestPriorityAnimal);
                CircusAnimals.Remove(highestPriorityAnimal);
                highestPriorityAnimal = null;
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
