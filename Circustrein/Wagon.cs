﻿using System;
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

        public Wagon(int WagonID)
        {
            animalsInWagon = new List<Animal>();
            Space = 10;
            UsedSpace = 0;
            Efficiency = "";
            wagonID = WagonID;
        }

        public bool AddAnimalToWagon(Animal animal)
        {
            if (animalsInWagon.Count == 0 || EnoughSpace(animal) && animalsInWagon[0].CompatibleWith(animal))
            {
                animalsInWagon.Add(animal);
                UsedSpace += Convert.ToInt32(animal.Size);
                Efficiency = $"{UsedSpace} / {Space}";
                return true;
            }
            return false;
        }

        private bool EnoughSpace(Animal animal)
        {
            return Space >= (UsedSpace + Convert.ToInt32(animal.Size));
        }

        public IReadOnlyList<Animal> GetAnimalsInWagon()
        {
            return animalsInWagon.AsReadOnly();
        }

        public override string ToString()
        {
            return $"Wagon {wagonID}";
        }
    }
}
