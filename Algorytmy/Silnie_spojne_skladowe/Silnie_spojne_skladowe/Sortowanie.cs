using System;
using System.Collections.Generic;
using System.Text;

namespace Silnie_spojne_skladowe
{
    class Sortowanie
    {
        public void SwapValues(pair[] source, long index1, long index2)
        {
            pair temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }

        public void sortujKopcowo(pair[] tablica)
        {
            int tabRoz = tablica.Length;
            for (int j = tabRoz / 2 - 1; j >= 0; j--)
            {
                waliduj(tablica, tabRoz, j);
            }
            for (int j = tabRoz - 1; j > 0; j--)
            {
                SwapValues(tablica, 0, j);
                tabRoz--;
                waliduj(tablica, tabRoz, 0);
            }
        }

        public void waliduj(pair[] tablica, int wielkoscKopca, int indeksRodzica)
        {
            int maxIndeks = indeksRodzica;
            int dzieckoLewe = indeksRodzica * 2 + 1;
            int praweDziecko = indeksRodzica * 2 + 2;

            if (dzieckoLewe < wielkoscKopca && tablica[dzieckoLewe].b > tablica[maxIndeks].b)
            {
                maxIndeks = dzieckoLewe;
            }
            if (praweDziecko < wielkoscKopca && tablica[praweDziecko].b > tablica[maxIndeks].b)
            {
                maxIndeks = praweDziecko;
            }
            if (maxIndeks != indeksRodzica)
            {
                SwapValues(tablica, maxIndeks, indeksRodzica);
                waliduj(tablica, wielkoscKopca, maxIndeks);
            }

        }
    }
}
