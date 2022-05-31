using System;
using System.Collections.Generic;
using System.Text;

namespace Edmondsa_Karpa
{
    class Krawedz
    {
        public int maks;
        public int obecny;
        public int w2;

        public Krawedz(int maks, int w2)
        {
            this.maks = maks;
            this.w2 = w2;
            obecny = 0;
        }

        public void wypisz()
        {
            Console.WriteLine("maksymalny przesyl=" + maks);
            Console.WriteLine("wierzcholek b=" + w2);
            Console.WriteLine("obecnie zajety przesyl=" + obecny);
        }
    }
}
