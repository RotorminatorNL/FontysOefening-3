using System;
using System.Collections.Generic;

namespace Circustrein
{
    public class Wagon
    {
        private readonly List<Animal> animalsInWagon;
        private readonly int wagonID;

        public readonly int Space;
        public int UsedSpace { get; private set; }
        public string Efficiency { get; private set; }
        public int AmountAnimals { get; private set; }

        public Wagon(int WagonID)
        {
            animalsInWagon = new List<Animal>();
            Space = 10;
            UsedSpace = 0;
            Efficiency = "";
            AmountAnimals = 0;
            wagonID = WagonID;
        }

        public bool AddAnimalToWagon(List<Animal> animals, Animal animal)
        {
            if(EnoughSpace(animal))
            {
                bool animalIsCompatible = true;
                foreach (Animal a in animalsInWagon)
                {
                    if (!a.CompatibleWith(animal))
                    {
                        animalIsCompatible = false;
                    }
                }

                if (animalIsCompatible)
                {
                    animalsInWagon.Add(animal);
                    UsedSpace += Convert.ToInt32(animal.Size);
                    Efficiency = $"{UsedSpace} / {Space}";
                    AmountAnimals++;
                    animals.Remove(animal);
                    return true;
                }
            }
            return false;
        }

        private bool EnoughSpace(Animal animal)
        {
            return Space >= (UsedSpace + Convert.ToInt32(animal.Size));
        }

        public List<Animal> GetAnimalsInWagon()
        {
            List<Animal> animals = new List<Animal>();
            foreach (Animal animal in animalsInWagon)
                animals.Add(animal);
            return animals;
        }

        public override string ToString()
        {
            return $"Wagon {wagonID}";
        }
    }
}
