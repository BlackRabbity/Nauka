using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulyKryptograficzne
{
    class PrzedstawieniaMacierzoweB
    {
        public string Szyfruj(string napis, string key)
        {

            int pom = 0;
            string wynik = null;

            double wiersze = Convert.ToDouble(napis.Length) / Convert.ToDouble(key.Length);
            wiersze = Math.Ceiling(wiersze);
            char[,] tab = new char[(int)wiersze, key.Length];       // tworzenie odpowiedniej wielkościowo tablicy

            for(int j=0; j<(int)wiersze; j++)
            {
                for(int i=0; i<key.Length; i++)
                {
                    if(pom < napis.Length && napis[pom] == ' ')     // pominięcie spacji przy wpisywaniu do tablicy
                    {
                        pom++;
                        i--;
                    }else
                    if (pom < napis.Length)                         // pom nie może wykraczać poza długość napisu
                    {
                        tab[j, i] = napis[pom];
                        pom++;
                    }
                }
            }                                                       // wypełnienie tablicy napisem do szyfrowania

            List<char> keyList = new List<char>();
            for(int i=0; i<key.Length; i++)
            {
                keyList.Add(key[i]);
            }                                                       
            keyList.Sort();                                         // dodanie listy przechowującej znaki klucza i posortowanie tych znaków
            pom = 0;
            char[] tabKey = key.ToCharArray();                      // stworzenie tablicy char, ponieważ zwykłego string nie można modyfikować

            for (int j=0; j<key.Length; j++)
            {
                for(int i=0; i < key.Length; i++)                   // sprawdzana jest cała tablica
                {
                    if (keyList[j] == tabKey[i])                    // gdy posortowana litera jest równa literze w kluczu
                    {
                        for(int k=0; k<(int)wiersze; k++)           // czytanie wszystkich wierszy tej samej kolumny
                        {
                            if(tab[k,i] != '\0')                    // jeśli komórka w tabeli jest pusta, pomijana jest
                            wynik += tab[k, i];                     // i - indeks litery(posortowanej) w kluczu
                        }

                        keyList[j] = (char)i;                       
                        tabKey[i] = '0';                            // nadpisanie listy i tablicy, żeby 2 razy nie wziąć tego samego
                        break;
                    }
                }
            }
            return wynik;
        }


        public string Deszyfruj(string napis, string key)
        {


            int pom = 0;
            string wynik = null;

            double wiersze = Convert.ToDouble(napis.Length) / Convert.ToDouble(key.Length);
            wiersze = Math.Ceiling(wiersze);
            char[,] tab = new char[(int)wiersze, key.Length];               // tworzenie odpowiedniej wielkościowo tablicy

            for (int j = 0; j < (int)wiersze; j++)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (pom < napis.Length && napis[pom] == ' ')             // pominięcie spacji przy wpisywaniu do tablicy
                    {
                        pom++;
                        i--;
                    }
                    else
                    if (pom < napis.Length)                                 // pom nie może wykraczać poza długość napisu
                    {
                        tab[j, i] = '0';
                        pom++;
                    }
                }
            }                                                               // wypełnienie tablicy znakiem w którym ma się znajdować litera

            List<char> keyList = new List<char>();
            for (int i = 0; i < key.Length; i++)
            {
                keyList.Add(key[i]);
            }
            keyList.Sort();                                                 // dodanie listy przechowującej znaki klucza i posortowanie tych znaków
            pom = 0;
            char[] tabKey = key.ToCharArray();                              // stworzenie tablicy char, ponieważ zwykłego string nie można modyfikować

            for (int j = 0; j < key.Length; j++)
            {
                for (int i = 0; i < key.Length; i++)                        // sprawdzana jest cała tablica
                {
                    if (keyList[j] == tabKey[i])                            // gdy posortowana litera jest równa literze w kluczu
                    {
                        for (int k = 0; k < (int)wiersze; k++)              // czytanie wszystkich wierszy tej samej kolumny
                        {
                            if (tab[k, i] == '0' && pom < napis.Length)     // jeśli komórka w tabeli została wcześniej nadpisana
                            {
                                if (napis[pom] == ' ')                      // pomijane zostają spacje
                                {
                                    pom++;
                                    k--;
                                } else
                                {
                                    tab[k, i] = napis[pom];
                                    pom++;
                                }
                            }
                        }

                        keyList[j] = (char)i;
                        tabKey[i] = '0';                                    // nadpisanie listy i tablicy, żeby 2 razy nie wziąć tego samego
                        break;
                    }
                }
            }

            for (int j = 0; j < (int)wiersze; j++)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (tab[j,i] != '\0')
                    {
                        wynik += tab[j, i];
                    }
                }
            }
            return wynik;
        }
    }
}
