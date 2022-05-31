using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Silnie_spojne_skladowe
{
    class Program
    {
        static void Main()
        {

            int W = Int32.Parse(File.ReadLines(@"D:\Michal\in0403.txt").First());

            List<int>[] G = new List<int>[W + 1];
            List<int>[] GT = new List<int>[W + 1];

            for (int i = 1; i <= W; i++)
            {
                G[i] = new List<int>();
            }
            for (int i = 1; i <= W; i++)
            {
                GT[i] = new List<int>();
            }
            int pom = 1;
            foreach (string linia2 in File.ReadLines(@"D:\Michal\in0403.txt").Skip(1))
            {
                string[] pomoc = linia2.Split(' ');
                for (int i = 0; i < pomoc.Length; i++)
                {
                    G[pom].Add(Int32.Parse(pomoc[i]));
                }
                pom++;
            }                                        // koniec zczytywania do pliku powstała tablica list: G reprezentująca graf


            bool[] odw = new bool[W + 1];            // tablica odwiedzonych G
            bool[] odwT = new bool[W + 1];           // tablica odwiedzonych GT
            int[] d = new int[W + 1];                // tablica czasów wejsc
            int[] f = new int[W + 1];                // tablica czasów wyjsc

            int t = 0;                               // aktualny czas

            int[] wG = new int [W];                  // tablica liczb jakie wchodzą podczas wykonywania dla G
            int wGlicznik = t;                       // iterowanie po tablicy wG
            int[] wGT = new int[W];                  // tablica liczb jakie wchodzą podczas wykonywania dla GT
            int wGTlicznik = t;                      // iterowanie po tablicy wGT
            int[] wierzpost = new int [W * 2 + 1];   // dla czasów wyjścia trzyma wierzchołki (odwrotność f), służy do iteracji w czasie liniowym czasów wyjścia
            int nrSklad = 0;                         // ilość silnie spójnych składowych                         
            string linia4 = "";                      // linia wypisująca silnie spójne składowe

            for (int i = 1; i <= W; ++i)
            {
                for (int j = 0; j < G[i].Count(); j++)
                {
                    GT[G[i][j]].Add(i);
                }
            }                                       // transpozycja G na GT


            void DFS(int v, int[] wG)               // algorytm przeglądania w głąb na grafie G
            {
                if (odw[v] != true)                 // algorytm wykonuje się, aż nie sprawdzi wszystkich wierzchołków
                {
                    odw[v] = true;                  // zaznacza odwiedzony wierzchołek
                    wG[wGlicznik++] = v;            // wrzucanie po kolei wierzchołków w kolejności ich przeglądania na DFS i zwiększenie licznika
                    t++;                            // powiększenie czasu
                    d[v] = t;                       // przypisanie wierzchołkowi czas jego wejścia
                    foreach (var a in G[v])         // wykonanie algorytmu DFS na wszystkich sąsiednich nieodwiedzonych wierzchołkach (rekurencyjnie)
                    {
                        if (!odw[a])
                        {
                            DFS(a, wG);
                        }
                    }
                    t++;                            // zwiększenie czasu
                    f[v] = t;                       // przypisanie wierzchołkowi czas jego wyjścia
                    wierzpost[t] = v;               // dla danego czasu postorder jest trzymana tutaj wierzchołek v
                }
            }
            void DFSgt(int v, int[] wGT)            // algorytm przeglądania w głąb na grafie GT
            {
                if (odwT[v] != true)                // algorytm wykonuje się, aż nie sprawdzi wszystkich wierzchołków
                {
                    odwT[v] = true;                 // zaznacza odwiedzony wierzchołek
                    wGT[wGTlicznik++] = v;          // wrzucanie po kolei wierzchołków w kolejności ich przeglądania na DFS i zwiększenie licznika
                    linia4 += v+" ";                // dodanie wierzchołka do silnie spójnej składowej
                    foreach (var a in GT[v])        // wykonanie algorytmu DFS na wszystkich sąsiednich nieodwiedzonych wierzchołkach (rekurencyjnie)
                    {
                        if (!odwT[a])
                        {
                            DFSgt(a, wGT);
                        }
                    }
                }
            }

            for (int i=1; i<W+1; i++)               // DFS po G po wszystkich nieodwiedzonych wierzchołkach
            {
                if(odw[i] != true) 
                {
                    DFS(i, wG);
                }
            }


            for(int i=t; i>0 ;i--)                 // DFS po GT, po wszystkich nieodwiedzonych wierzchołkach w kolejności największego czasu przetworzenia do najmniejszego
            {
                if (wierzpost[i] != 0)
                {
                    if (odwT[wierzpost[i]] != true) // jeśli nieodwiedzony jest wierzchołek dla danego czasu przetworzenia
                    {
                        linia4 += "{ ";
                        DFSgt(wierzpost[i], wGT);
                        nrSklad++;
                        linia4 += "}";
                    }
                }
            }

            for (int i = 0; i < wG.Count(); i++)
            {
                Console.WriteLine(wG[i]);
            }

            using (StreamWriter writer = new StreamWriter(@"D:\Michal\out0403.txt"))
            {
                for (int i=1; i< W+1; i++)
                {
                    writer.Write("[" + i + "]" + "(" + d[i] + "/" + f[i] + ") ");
                }
                writer.WriteLine();
                for (int i = 0; i < W; i++)
                {
                    writer.Write(wG[i]+" ");
                }
                writer.WriteLine();
                for (int i = 0; i < W; i++)
                {
                    writer.Write(wGT[i]+" ");
                }
                writer.WriteLine();
                writer.Write(linia4);
                writer.WriteLine();
                writer.Write(nrSklad);
            }
        }
    }
}
