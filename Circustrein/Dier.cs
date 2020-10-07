using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Dier
    {
        public enum Groottes
        {
            klein = 1,
            middelgroot = 3,
            groot = 5
        }

        public enum Types
        {
            planteter = 1,
            vleeseter = 2
        }

        public Groottes Grootte { get; private set; }
        public Types Type { get; private set; }
        public string Naam { get; private set; }

        public Dier(Groottes grootte, Types type)
        {
            Grootte = grootte;
            Type = type;
            Naam = $"{grootte} {type}";
        }
    }
}
