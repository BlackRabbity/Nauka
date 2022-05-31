using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edmondsa_Karpa
{
    class Program
    {
        static void Main()
        {
            string linia = File.ReadLines(@"D:\Michal\in0402.txt").First();
            string[] tablicaPomoc = new string[2];
            tablicaPomoc = linia.Split(' ');
            int n = int.Parse(tablicaPomoc[0]);                                 // n liczba wierzchołków (ilość węzłów w sieci)
            int s = int.Parse(tablicaPomoc[1]);                                 // s źródło
            int t = int.Parse(tablicaPomoc[2]);                                 // t ujście

            List<Krawedz>[] listaI = new List<Krawedz>[n + 1];                  // lista incydencji

            for (int i = 1; i <= n; i++)
            {
                listaI[i] = new List<Krawedz>();
            }

            List<Krawedz>[] listaIT = new List<Krawedz>[n + 1];                  // lista odwrocona

            for (int i = 1; i <= n; i++)
            {
                listaIT[i] = new List<Krawedz>();
            }

            Wierzcholek[] tablicaW = new Wierzcholek[n + 1];                     // tablica wierzchołków

            for (int i = 1; i <= n; i++)
            {
                if (i == s)
                {
                    tablicaW[s] = new Wierzcholek(Int32.MaxValue, -1);
                    tablicaW[s].nr = s;
                }
                else
                {
                    tablicaW[i] = new Wierzcholek();
                    tablicaW[i].nr = i;
                }
            }

            int j = 1;

            foreach (string linia2 in File.ReadLines(@"D:\Michal\in0402.txt").Skip(1))
            {
                if (j == t)
                {
                    j++;
                }
                string[] pomoc = linia2.Split(' ');
                for (int i = 1; i <= pomoc.Length; i += 2)
                {
                    Krawedz tymczasow = new Krawedz(int.Parse(pomoc[i]), tablicaW[int.Parse(pomoc[i - 1])].nr);
                    Krawedz tymczasow2 = new Krawedz(int.Parse(pomoc[i]), j);
                    listaI[j].Add(tymczasow);
                    listaIT[tablicaW[int.Parse(pomoc[i - 1])].nr].Add(tymczasow2);
                }
                j++;
            } // sczytywanie z pliku


            string liniaKolejka = "KOLEJKA= " + s + " ";                    // zmienna do pliku (po kolei wrzucane wierzchołki na kolejke)
            string sumaSciezek = "";                                        // zmienna do pliku (suma wszystkich przepływów które do ujścia wchodzą)
            int sS=0;                                                       // zmienna do pliku (zliczona suma przepływów)

            bool zmieniono = false;                                         // zmienna sprawdzająca czy etykieta w danym przejściu została nadana
            int u = 0;                                                      // sąsiad wierzchołka v
            Wierzcholek v;                                                  // wierzchołek
            Queue kolejka = new Queue();                                    // deklaracja kolejki

            using (StreamWriter writer = new StreamWriter(@"D:\Michal\out0402.txt"))  // zapis do pliku
            {
                void powiekszDroge(List<Krawedz>[] listaI, List<Krawedz>[] listaIT, Wierzcholek[] tablicaW, int s, int t, int v, int u) // funkcja powiększająca przepustowość na wszystkich
                {                                                                                                                       // wykorzystanych krawędziach od źródła do ujścia, które były na drodzę

                    writer.Write(t + " ");                          // do pliku wypisany powrót
                    while (v != s)                                  // dopóki nie dojdzie do źródła
                    {
                        v = tablicaW[u].poprzednik;                 // przypisanie v wartości poprzednika u

                        writer.Write(v + " ");                      // do pliku

                        //jeśli krawędź przednia:
                        for (int i = 0; i < listaI[v].Count; i++)
                        {
                            if (listaI[v][i].w2 == u)                               // szukanie prawidłowej krawędzi łączącej wierzchołek v oraz u
                            {
                                listaI[v][i].obecny += tablicaW[t].przepust;        // zwiększenie przepływu
                            }
                        }
                        for (int i = 0; i < listaIT[u].Count; i++)                  // równoległa zmiana na krawędzi odwrotnej (wstecznej)
                        {   
                            if (listaIT[u][i].w2 == v)                              // szukanie prawidłowej krawędzi łączącej wierzchołek v oraz u w liście krawędzi odwrotnych                  
                            {
                                listaIT[u][i].obecny -= tablicaW[t].przepust;       // zmniejszenie przepływu na krawędzi wstecznej
                            }
                        }

                        //jeśli krawędź wsteczna:
                        for (int i = 0; i < listaI[u].Count; i++)                   // w krawędzi wstecznej wykonywane jest odwrotne działanie do działania w krawędzi przedniej
                        {
                            if (listaI[u][i].w2 == v)
                            {
                                listaI[u][i].obecny -= tablicaW[t].przepust;
                            }
                        }
                        for (int i = 0; i < listaIT[v].Count; i++)
                        {
                            if (listaIT[v][i].w2 == u)
                            {
                                listaIT[v][i].obecny += tablicaW[t].przepust;
                            }
                        }
                        u = v;                                                      // przejście o 1 wierzchołek w stronę śródła
                    }
                    writer.WriteLine();
                }


                kolejka.Enqueue(tablicaW[s]);                                               // źródło zostaje wrzucone na kolejke

                while (kolejka.Count != 0)                                                  // sprawdza czy kolejka pusta
                {
                    v = (Wierzcholek)kolejka.Peek();                                        // przypisuje v wartość początku kolejki
                    kolejka.Dequeue();                                                      // zdjęcie z kolejki
                    for (int i = 0; i < Math.Max(listaI[v.nr].Count, listaIT[v.nr].Count); i++)         // pętla iterująca się po wszystkich sąsiadach w liścue I oraz IT
                    {
                        zmieniono = false;                                                  // resetowanie wartości: zmieniono

                        if (i < listaI[v.nr].Count && tablicaW[listaI[v.nr][i].w2].poprzednik == -1 && listaI[v.nr][i].maks - listaI[v.nr][i].obecny > 0)    // 1. nie wyjdzie poza rozmiar, 2. sprawdzanie czy wierzchołek jest nadpisany, 3. jeśli można nadpisać krawędź
                        {
                            zmieniono = true;                                               // nadano wierzchołkowi etykiete
                            tablicaW[listaI[v.nr][i].w2].poprzednik = v.nr;                 // ustawienie poprzednika sąsiada, wierzchołka u
                            tablicaW[listaI[v.nr][i].w2].przepust = Math.Min(listaI[v.nr][i].maks - listaI[v.nr][i].obecny, tablicaW[v.nr].przepust);       // ustawianie przepustowości na wierzchołku
                            u = tablicaW[listaI[v.nr][i].w2].nr;                            // przypisanie wartości wierzchołkowi u

                        }
                        else
                        if (i < listaIT[v.nr].Count && tablicaW[listaIT[v.nr][i].w2].poprzednik == -1 && listaIT[v.nr][i].obecny > 0) // 1. nie wyjdzie poza rozmiar, 2. sprawdzanie czy wierzchołek jest nadpisany, 3. jeśli można nadpisać krawędź
                        {
                            zmieniono = true;                                               // nadano wierzchołkowi etykiete
                            tablicaW[listaIT[v.nr][i].w2].poprzednik = v.nr;                // ustawienie poprzednika sąsiada, wierzchołka u
                            tablicaW[listaIT[v.nr][i].w2].przepust = Math.Min(listaIT[v.nr][i].obecny, tablicaW[v.nr].przepust);    // ustawianie przepustowości na wierzchołku
                            u = tablicaW[listaIT[v.nr][i].w2].nr;                           // przypisanie wartości wierzchołkowi u
                        }
                        if (zmieniono)                                                      // jeśli kolejny wierzchołek został zaktualizowany
                        {
                            if (u != t)                                                     // jeśli ten sąsiadujący wierzchołek nie jest ujściem
                            {
                                kolejka.Enqueue(tablicaW[u]);                               // wrzucenie do kolejki wierzchołka sąsiadującego
                                liniaKolejka += tablicaW[u].nr + " ";                       // do pliku, dodanie wziętego sąsiada
                            }
                            else
                            {
                                writer.WriteLine(liniaKolejka);                             // wrzucenie do pliku kolejki
                                liniaKolejka = "KOLEJKA= " + s + " ";                       // restartowanie wartości: liniaKolejka

                                powiekszDroge(listaI, listaIT, tablicaW, s, t, v.nr, u);    // lista krawędzi, lista odwróconych krawędzi, tablica wierzchołków, źródło, ujście, nr.wierzchołka, wierzchołek sądziadujący
                                kolejka.Clear();                                            // czyszczenie kolejki
                                kolejka.Enqueue(tablicaW[s]);                               // na początek kolejki wstawiane źródło
                                for (int k = 1; k < tablicaW.Length; k++)                   // resetowanie wartości wierzchołków
                                {
                                    if (k == s)
                                    {
                                        continue;
                                    }
                                    tablicaW[k].przepust = 0;
                                    tablicaW[k].poprzednik = -1;
                                }
                                break;
                            }
                        }
                    }
                }
                for (int i = 1; i < n + 1; i++)                                             // zapis do pliku
                {
                    writer.Write("[" + i + "]");
                    for (int a = 0; a < listaI[i].Count; a++)
                    {
                        writer.Write(listaI[i][a].w2 + " ");
                        writer.Write(listaI[i][a].obecny + ",");
                    }
                    writer.WriteLine();
                }
                for (int i = 1; i < n + 1; i++)
                {
                    for (int a = 0; a < listaI[i].Count; a++)
                    {
                        if (listaI[i][a].w2 == t)
                        {
                            sumaSciezek += listaI[i][a].obecny +"+";
                            sS += listaI[i][a].obecny;
                        }
                    }
                }
                if (sumaSciezek != "")
                sumaSciezek = sumaSciezek.Remove(sumaSciezek.Length - 1);
                writer.Write(sumaSciezek + "=" + sS);
            }
        
        }
    }
}
