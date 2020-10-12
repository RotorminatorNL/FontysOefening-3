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
