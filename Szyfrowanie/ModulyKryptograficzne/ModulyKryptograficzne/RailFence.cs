using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulyKryptograficzne
{
    class RailFence
    {
        public string Szyfruj(string napis, int n)
        {
            bool zmiana = false;
            string wynik = null;
            char[,] tab = new char[n, napis.Length];
            int j = 0;
            for (int i = 0; i < napis.Length; i++)
            {
                tab[j, i] = napis[i];               // wypełnienie tablicy w odpowiednich miejscach

                if (n <= 1)                         // jeśli n < 1 nic się nie dzieje
                {

                }else if (zmiana == false)          // póki jest kierunek do dołu
                {
                    j++;
                    if (j == n)                     // gdy dojdzie do samego dołu następuje zmiana kierunku (zmina = true)
                    {
                        j--;
                        zmiana = true; 
                    }
                }
                if (zmiana == true)                 // póki jest kierunek do góry
                {
                    j--;
                    if (j == 0)                     // gdy dojdzie do samej góry następuje zmiana kierunku (zmina = false)
                    {
                        zmiana = false;
                    }
                }
            }
            for (j = 0; j < n; j++)
            {
                for (int i = 0; i < napis.Length; i++)      // wypisywanie  wierszami od pierwszego
                {
                    if (tab[j, i] != '\0')                  // jeśli tablica nie została wypełniona, komórka jest pomijana
                        wynik += tab[j, i];
                }
            }
            return wynik;
        }


        public string Deszyfruj(string napis, int n)
        {
            bool zmiana = false;
            string wynik = null;
            char[,] tab = new char[n, napis.Length];
            int pom = 0;
            int j = 0;
            for (int i = 0; i < napis.Length; i++)          // wypełnienie tablicy 0 w miejscach gdzie powinny znaleźć się napis
            {
                tab[j, i] = '0';

                if (n <= 1)
                {

                }
                else if (zmiana == false)                   
                {
                    j++;
                    if (j == n)
                    {
                        j--;
                        zmiana = true;
                    }
                }
                if (zmiana == true)
                {
                    j--;
                    if (j == 0)
                    {
                        zmiana = false;
                    }
                }
            }

            for(int k=0; k< n; k++)                         // w miejscach gdzie jest 0 wstawienie napisu
            {
                for(int i=0; i<napis.Length; i++)
                {
                    if (tab[k,i] == '0')
                    {
                        tab[k, i] = napis[pom];
                        pom++;
                    }
                }

            }
            j = 0;
            zmiana = false;
            for (int i = 0; i < napis.Length; i++)         // odczytanie napisu w ten sam sposób co był on tworzony
            {
                wynik += tab[j, i];

                if (n <= 1)
                {

                }
                else if (zmiana == false)
                {
                    j++;
                    if (j == n)
                    {
                        j--;
                        zmiana = true;
                    }
                }
                if (zmiana == true)
                {
                    j--;
                    if (j == 0)
                    {
                        zmiana = false;
                    }
                }
            }
            return wynik;
        }
    }
}
