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
            // vul wagon met dieren
            // wagon vol add wagon aan trein
            // nieuw wagon vullen
            // trein klaar wanneer alle dieren in een wagon zijn

            Wagon wagon;

            for (int i = 0; i < circusAnimals.Count; i++)
            {
                wagon = new Wagon(trainWagons.Count + 1);
                totalSpace += wagon.Space;

                Animal primaryAnimal = circusAnimals[i];
                wagon.AddAnimalToWagon(circusAnimals, primaryAnimal);
                totalUsedSpace += primaryAnimal.Weight;

                for (int j = 0; j < circusAnimals.Count; j++)
                {
                    Animal secondaryAnimal = circusAnimals[j];
                    if (wagon.UsedSpace + secondaryAnimal.Weight <= wagon.Space)
                    {
                        if (primaryAnimal.Type == Types.vleeseter && primaryAnimal.Size == Sizes.kleine && secondaryAnimal.Type != Types.vleeseter && secondaryAnimal.Weight == Convert.ToInt32(Sizes.middelgrote))
                        {
                            j = AddAnimal(circusAnimals, secondaryAnimal, wagon);
                        }
                        else if (primaryAnimal.Type == Types.vleeseter && primaryAnimal.Size != Sizes.kleine && secondaryAnimal.Type != Types.vleeseter && secondaryAnimal.Weight > primaryAnimal.Weight)
                        {
                            j = AddAnimal(circusAnimals, secondaryAnimal, wagon);
                        }
                        else if (primaryAnimal.Type != Types.vleeseter)
                        {
                            j = AddAnimal(circusAnimals, secondaryAnimal, wagon);
                        }
                    }
                }

                trainWagons.Add(wagon);
                i = -1;
            }

            return this;
        }

        private int AddAnimal(List<Animal> animals, Animal animal, Wagon wagon)
        {
            wagon.AddAnimalToWagon(animals, animal);
            totalUsedSpace += animal.Weight;
            return -1;
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
