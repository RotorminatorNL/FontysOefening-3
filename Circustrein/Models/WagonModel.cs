using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein.Models
{
    public class WagonModel
    {
        public int WagonID { get; private set; }
        public int MaxAmount { get; private set; } = 10;
        public int AmountAnimalsOnBoard { get; private set; } = 0;
        public List<AnimalModel> Animals { get; private set; } = new List<AnimalModel>();

        /// <summary>
        /// Create a new wagon with a unique WagonID
        /// </summary>
        /// <param name="AmountOfExistingWagons">Amount of existing wagons</param>
        public WagonModel(int AmountOfExistingWagons)
        {
            WagonID = AmountOfExistingWagons + 1;
        }
    }
}
