using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Mec mec = new Mec(20);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 10, 10, mec);
            Hrdina hrdina2 = new Hrdina("Dovahkiin2", 100, 10, 10);
            Hrdina hrdina3 = new Hrdina("Dovahkiin3", 100, 10, 10);
            Drak drak = new Drak("Alduin", 100, 100, 11, 10);
            Drak drak2 = new Drak("Šmak2", 100, 100, 11, 10);
            Drak drak3 = new Drak("Šmak3", 100, 100, 11, 10);
            Vlk vlk = new Vlk("Wolfie", 50, 50, 5, 5);
            Vlk vlk2 = new Vlk("Wolfie2_2", 50, 50, 5, 5);
            Vlk vlk3 = new Vlk("Wolfie2_3", 50, 50, 5, 5);

            /*Arena arena = new Arena(hrdina, drak);
            arena.Boj();*/

            List<Postava> postavy = new List<Postava> { hrdina, drak, vlk };
            List<Postava> postavy2 = new List<Postava> { vlk2, hrdina2, drak2 };
            List<Postava> postavy3 = new List<Postava> { hrdina3, drak3, vlk3 };
            postavy.Add(new Hrdina("Hrdina 5", 100, 10, 10));

            //Array.Sort(postavy);
            //Array.Reverse(postavy);
            postavy.Sort();
            postavy.Reverse();

            //postavy.Remove(drak2);
            //postavy.RemoveAt(1);
            foreach (var postava in postavy)
            {
                Console.WriteLine(postava.ToString());
            }
            Console.WriteLine(String.Empty);

            ArenaProPostavy arena = new ArenaProPostavy(postavy);
            arena.StatistikyPostav();
            arena.Boj();

            Console.WriteLine("synchronní boj ukončen" + Environment.NewLine);

            ArenaProPostavy arena2 = new ArenaProPostavy(postavy2);
            ArenaProPostavy arena3 = new ArenaProPostavy(postavy3);
            await arena2.BojAsync();
            arena3.BojAsync();

            Console.ReadKey();
        }
    }
}
