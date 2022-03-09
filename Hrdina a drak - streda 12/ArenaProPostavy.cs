using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_12
{
    public class ArenaProPostavy
    {
        public Postava[] Postavy { get; set; }
        public ArenaProPostavy(Postava[] postavy)
        {
            Postavy = postavy;
        }

        public void Boj()
        {
            while (LzeBojovat())
            {
                for (int i = 0; i < Postavy.Length; ++i)
                {
                    Postava utocnik = Postavy[i];
                    if (utocnik.MuzeBojovat())
                    {
                        Postava oponent = utocnik.VyberOponenta(Postavy);
                        if (oponent != null)
                        {
                            double utok = utocnik.Utok(oponent);
                            Console.WriteLine($"{utocnik.Jmeno} zaútočil hodnotou {utok}. {oponent.Jmeno} má {oponent.Zdravi} životů.");

                            if (oponent.MuzeBojovat())
                            {
                                utok = oponent.Utok(utocnik);
                                Console.WriteLine($"{oponent.Jmeno} provedl protiútok hodnotou {utok}. {utocnik.Jmeno} má {utocnik.Zdravi} životů.");
                            }
                        }
                    }
                }

                Console.WriteLine(String.Empty);
            }
        }

        public bool LzeBojovat()
        {
            if (PocetBojujicichPostav() > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PocetBojujicichPostav()
        {
            int pocet = 0;
            foreach (var postava in Postavy)
            {
                if (postava.MuzeBojovat())
                    ++pocet;
            }
            return pocet;
        }

    }
}
