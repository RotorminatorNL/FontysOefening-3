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

            for (int a_1 = 0; a_1 < circusAnimals.Count; a_1++)
            {
                wagon = new Wagon(trainWagons.Count + 1);
                totalSpace += wagon.Space;

                Animal animal_1 = circusAnimals[a_1];
                wagon.AddAnimalToWagon(circusAnimals, animal_1);
                totalUsedSpace += animal_1.Weight;

                for (int a_2 = 0; a_2 < circusAnimals.Count; a_2++)
                {
                    Animal animal_2 = circusAnimals[a_2];
                    if (wagon.UsedSpace + animal_2.Weight <= wagon.Space)
                    {
                        if (animal_1.Type == Types.vleeseter && animal_1.Size == Sizes.kleine && animal_2.Type != Types.vleeseter && animal_2.Weight == Convert.ToInt32(Sizes.middelgrote))
                        {
                            wagon.AddAnimalToWagon(circusAnimals, animal_2);
                            totalUsedSpace += animal_2.Weight;
                            a_2 = -1;
                        }
                        else if (animal_1.Type == Types.vleeseter && animal_1.Size != Sizes.kleine && animal_2.Type != Types.vleeseter && animal_2.Weight > animal_1.Weight)
                        {
                            wagon.AddAnimalToWagon(circusAnimals, animal_2);
                            totalUsedSpace += animal_2.Weight;
                            a_2 = -1;
                        }
                        else if (animal_1.Type != Types.vleeseter)
                        {
                            wagon.AddAnimalToWagon(circusAnimals, animal_2);
                            totalUsedSpace += animal_2.Weight;
                            a_2 = -1;
                        }
                    }
                }

                trainWagons.Add(wagon);
                a_1 = -1;
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
