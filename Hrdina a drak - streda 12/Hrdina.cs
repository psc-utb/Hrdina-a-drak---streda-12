using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_12
{
    public class Hrdina : Postava
    {
        public Mec Mec { get; set; }

        public Hrdina(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax, Mec mec) : base(jmeno, zdravi, zdraviMax, poskozeniMax, zbrojMax)
        {
            Mec = mec;
        }

        public Hrdina(string jmeno, double zdraviMax, double poskozeniMax, double zbrojMax) : this(jmeno, zdraviMax, zdraviMax, poskozeniMax, zbrojMax, null)
        {
        }


        public override double Utok(Postava oponent)
        {
            if (Mec != null)
            {
                return Utok(oponent, Mec.PoskozeniMax);
            }
            else
            {
                //return Utok(oponent, PoskozeniMax);
                return base.Utok(oponent);
            }
        }

        public override bool KontrolaOponenta(Postava oponent)
        {
            return true;
        }
    }
}
