using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein.Models
{
    public class AnimalModel
    {
        public string Info { get; private set; }
        public int Size { get; private set; }
        public int Type { get; private set; }

        /// <summary>
        /// Create new animal with 
        /// </summary>
        /// <param name="info">The information about the animal, exp: Grootte vleeseter</param>
        /// <param name="size">The size of the animal. (5=big, 3=medium, 1=small)</param>
        /// <param name="type">The type of the animal. (1=meat eater, 2=plant eater)</param>
        public AnimalModel(string info, int size, int type)
        {
            Info = info;
            Size = size;
            Type = type;
        }
    }
}
