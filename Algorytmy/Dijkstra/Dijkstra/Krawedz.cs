using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    class Krawedz
    {
        public int waga;
        public int w1, w2;
        public Krawedz()
        {
            waga = 0;
            w1 = 0;
            w2 = 0;
        }
        public Krawedz(int _waga, int _w1, int _w2)
        {
            waga = _waga;
            w1 = _w1;
            w2 = _w2;
        }

        public void wypisz()
        {
            Console.WriteLine("Waga=" + waga);
            Console.WriteLine("w1=" + w1);
            Console.WriteLine("w2=" + w2);
        }
    }
}
