using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulyKryptograficzne
{
    class PrzedstawieniaMacierzoweA
    {
        public string Szyfruj(string napis, string key)
        {
            string number = "0";
            string bigNumber = "0";
            int pom = 0;
            string wynik = null;

            for (int i=0; i< key.Length; i++)
            {
                if(key[i]!= '-')                                    // z klucza zostały wyciągnięte same liczby
                {
                    number += key[i];
                }
                if (Int32.Parse(bigNumber) < Int32.Parse(number))   // sprawdzono która liczba w kluczu jest największa
                {
                    bigNumber = number;
                }
                number = "0";
            }
            int[] pomTab = new int[Int32.Parse(bigNumber)];         // tablica pomocnicza reprezentująca kolejność klucza
            int k = 0;
            for (int i = 0; i < key.Length; i++)                    // pętla uzupełniająca tablicę pomocniczą
            {
                if (key[i] != '-')
                {
                    number += key[i];
                } else
                {
                    pomTab[k] = Int32.Parse(number)-1;
                    number = "0";
                    k++;
                }
            }
            pomTab[k] = Int32.Parse(number)-1;
            double wiersze = napis.Length / Convert.ToDouble(bigNumber);
            wiersze = Math.Ceiling(wiersze);                                    // wiersze w tablicy to zaookrąglenie długości napisu 
                                                                                // dzielonego przez największą liczbę klucza
            char[,] tab = new char[(int)wiersze, Int32.Parse(bigNumber)];       // ilość kolumn w tablicy reprezentuje największa liczba klucza



            for (int j = 0; j < (int)wiersze; j++)                              // wypełnienie tablicy wierszami napisem do szyfrowania
            {
                for (int i = 0; i < Int32.Parse(bigNumber); i++)
                {
                    if (pom >= napis.Length)
                    {
                    }else
                    {
                        tab[j, i] = napis[pom];
                        pom++;
                    }
                }
            }

            for (int j = 0; j < (int)wiersze; j++)
            {
                for (int i = 0; i < pomTab.Length; i++)
                {
                    if (tab[j,pomTab[i]] != '\0')                               // branie tylko z miejsc które zostały wypełnione w tablicy
                    wynik += tab[j, pomTab[i]];                                 // za pomocą tablicy pomocniczej zostają wybrane znaki w kolejności klucza
                }
            }
            return wynik;
        }


        public string Deszyfruj(string napis, string key)
        {

            string number = "0";
            string bigNumber = "0";
            int pom = 0;
            string wynik = null;

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] != '-')
                {
                    number += key[i];
                }
                if (Int32.Parse(bigNumber) < Int32.Parse(number))
                {
                    bigNumber = number;
                }
                number = "0";
            }
            int[] pomTab = new int[Int32.Parse(bigNumber)];
            int k = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] != '-')
                {
                    number += key[i];
                }
                else
                {
                    pomTab[k] = Int32.Parse(number) - 1;
                    number = "0";
                    k++;
                }
            }
            pomTab[k] = Int32.Parse(number) - 1;

            double wiersze = napis.Length / Convert.ToDouble(bigNumber);
            wiersze = Math.Ceiling(wiersze);
            char[,] tab = new char[(int)wiersze, Int32.Parse(bigNumber)];
            pom = 0;                                                            // koniec przygotowania elementów


            for (int j = 0; j < (int)wiersze; j++)
            {
                for (int i = 0; i < pomTab.Length; i++)
                {
                    if (pom < napis.Length)
                    {
                        tab[j, i] = '0';
                    }
                    pom++;
                }
            }                                                                   // wypełnienie tablicy miejscami gdzie powinny znajdować się litery

            pom = 0;
            for (int j = 0; j < (int)wiersze; j++)
            {
                for (int i = 0; i < pomTab.Length; i++)
                {
                    if (napis.Length > pom && tab[j,pomTab[i]] == '0')          // wstawianie w miejsca tylko gdzie jest '0'
                    {
                        tab[j, pomTab[i]] = napis[pom];
                        pom++;
                    }
                           
                }
            }

            for (int j = 0; j < (int)wiersze; j++)                              // odczytanie pokolei wierszami tablice uzupełnioną wcześniej
            {
                for (int i = 0; i < pomTab.Length; i++)
                {
                    if (tab[j, i] != '\0')
                    {
                        wynik += tab[j, i];
                    }
                           
                }
            }

            return wynik;
        }
    }
}
