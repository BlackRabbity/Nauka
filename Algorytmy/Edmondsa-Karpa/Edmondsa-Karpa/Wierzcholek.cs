using System;
using System.Collections.Generic;
using System.Text;

namespace Edmondsa_Karpa
{
    class Wierzcholek
    {
        public int nr;
        public int przepust;
        public int poprzednik;

        public Wierzcholek()
        {
            przepust = 0;
            poprzednik = -1;
        }
        public Wierzcholek(int przepust, int poprzednik)
        {
            this.przepust = przepust;
            this.poprzednik = poprzednik;
        }

        public void wypisz()
        {
            Console.WriteLine("Przepustowosc na wierzcholku =" + przepust);
            Console.WriteLine("Poprzedni wierzcholek =" + poprzednik);
        }
    }
}
