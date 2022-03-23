using System;

namespace Hrdina_a_drak___streda_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Mec mec = new Mec(20);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 10, 10, mec);
            Hrdina hrdina2 = new Hrdina("Dovahkiin", 100, 10, 10);
            Drak drak = new Drak("Alduin", 100, 100, 11, 10);
            Drak drak2 = new Drak("Šmak", 100, 100, 11, 10);
            Vlk vlk = new Vlk("Wolfie", 50, 50, 5, 5);
            Vlk vlk2 = new Vlk("Wolfie2", 50, 50, 5, 5);

            /*Arena arena = new Arena(hrdina, drak);
            arena.Boj();*/

            Postava[] postavy = new Postava[] { hrdina, drak, vlk2, hrdina2, drak2, vlk };

            Array.Sort(postavy);
            Array.Reverse(postavy);
            foreach(var postava in postavy)
            {
                Console.WriteLine(postava.ToString());
            }
            Console.WriteLine(String.Empty);

            ArenaProPostavy arena = new ArenaProPostavy(postavy);
            arena.Boj();
        }
    }
}
