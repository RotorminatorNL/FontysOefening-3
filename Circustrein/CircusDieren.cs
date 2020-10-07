using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Circustrein
{
    public class CircusDieren
    {
        public List<Dier> Dieren { get; private set; }

        public CircusDieren()
        {
            Dieren = new List<Dier>();
        }

        public void VerzamelDieren(StackPanel spPlantEters, StackPanel spVleesEters)
        {
            foreach (TextBox textBox in spPlantEters.Children)
            {
                string[] arrPlantEter = textBox.Text.Split('_');

                if (Convert.ToInt32(arrPlantEter[1]) == (int)Dier.Groottes.klein)
                {
                    Dieren.Add(new Dier(Dier.Groottes.klein, Dier.Types.planteter));
                }
                else if (Convert.ToInt32(arrPlantEter[1]) == (int)Dier.Groottes.middelgroot)
                {
                    Dieren.Add(new Dier(Dier.Groottes.middelgroot, Dier.Types.planteter));
                }
                else
                {
                    Dieren.Add(new Dier(Dier.Groottes.groot, Dier.Types.planteter));
                }
            }

            foreach (TextBox textBox in spVleesEters.Children)
            {
                string[] arrVleesEter = textBox.Text.Split('_');

                if (Convert.ToInt32(arrVleesEter[1]) == (int)Dier.Groottes.klein)
                {
                    Dieren.Add(new Dier(Dier.Groottes.klein, Dier.Types.planteter));
                }
                else if (Convert.ToInt32(arrVleesEter[1]) == (int)Dier.Groottes.middelgroot)
                {
                    Dieren.Add(new Dier(Dier.Groottes.middelgroot, Dier.Types.planteter));
                }
                else
                {
                    Dieren.Add(new Dier(Dier.Groottes.groot, Dier.Types.planteter));
                }
            }
        }
    }
}
