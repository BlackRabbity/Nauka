using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dijkstra
{
    class Program
    {
        static void Main()
        {
            string linia = File.ReadLines(@"D:\Michal\in0304.txt").First();
            string[] tablicaPomoc = new string[2];
            tablicaPomoc = linia.Split(' ');
            int iloscW = int.Parse(tablicaPomoc[0]);
            int zrodlo = int.Parse(tablicaPomoc[1]);

            int[,] tablica = new int[iloscW + 1, iloscW + 1];
            int[] odleglosc = new int[iloscW + 1];
            int[] poprzednik = new int[iloscW+1];
            poprzednik[zrodlo] = -1;
            odleglosc[zrodlo] = 0;
            int k = 0;
            int j = 1;
            bool [] odwiedzone = new bool[iloscW + 1];
            bool odwWszystkie = false;

            foreach (string linia2 in File.ReadLines(@"D:\Michal\in0304.txt").Skip(1))
            {
                k = 0;
                string[] pomoc = linia2.Split(' ');
                for (int i = 1; i < iloscW + 1; i++)
                {
                    tablica[j, i] = int.Parse(pomoc[k]);
                    k++;
                }
                j++;
            }

            for (int i = 1; i <= iloscW; i++)
            {
                if (i != zrodlo) odleglosc[i] = Int32.MaxValue;
                else odleglosc[i] = 0;
            }

            int minOdleglosc, pom=0;

            while (odwWszystkie == false) 
            {
                {
                    minOdleglosc = Int32.MaxValue;

                    for (int i = 1; i <= iloscW; ++i)
                    {
                        if (odleglosc[i] < minOdleglosc && odwiedzone[i] == false)
                        {
                            minOdleglosc = odleglosc[i];
                            pom = i;
                        }
                    }
                }

                for (int i = 1; i <= iloscW; i++)
                {
                    if (tablica[pom, i] < 999)
                    {

                        if (odleglosc[pom] + tablica[pom, i] < odleglosc[i])
                        {
                            odleglosc[i] = odleglosc[pom] + tablica[pom, i];
                            poprzednik[i] = pom;
                        }
                    }
                }
                odwiedzone[pom] = true;
                for (int i = 1; i <= iloscW; ++i)
                {
                    if (odwiedzone[i] == false)
                    {
                        break;
                    }

                    else if (i == iloscW)
                    {
                        odwWszystkie = true;
                    }
                }
            }
            for (int i = 1; i < iloscW+1; i++)
            {
                Console.Write(odleglosc[i]+" ");
            }
            Console.WriteLine();
            for (int i = 1; i < iloscW+1; i++)
            {
                Console.Write(poprzednik[i] + " ");
            }

            using (StreamWriter writer = new StreamWriter(@"D:\Michal\out0304.txt"))
            {
                writer.Write("dist[");
                for (int i = 1; i < iloscW +1; i++)
                {
                    writer.Write(odleglosc[i] + " ");
                }
                writer.Write("]");
                writer.WriteLine();
                writer.Write("pred[");
                for (int i = 1; i < iloscW + 1; i++)
                {
                    writer.Write(poprzednik[i] + " ");
                }
                writer.Write("]");
            }
        }
    }
}
