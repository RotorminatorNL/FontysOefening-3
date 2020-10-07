using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Wagon
    {
        public List<Dier> DierenInwagon;
        private int MaxRuimte = 10;
        private int GebruikteRuimte;

        public Wagon()
        {
            DierenInwagon = new List<Dier>();
            GebruikteRuimte = 0;
        }

        public void VoegDierenToe(List<Dier> dieren)
        {

        }

        public string RuimteGebruik()
        {
            return $"{GebruikteRuimte} / {MaxRuimte}";
        }
    }
}
