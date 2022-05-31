using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Plecakowy
{
    class Program
    {
        static void Main()
        {
            string linia = File.ReadLines(@"D:\Michal\in0302.txt").First();
            string[] tablicaPomoc = new string[2];
            tablicaPomoc = linia.Split(' ');
            int n = int.Parse(tablicaPomoc[0]);
            int W = int.Parse(tablicaPomoc[1]);
            int arg = 1;

            int[] p = new int[int.Parse(tablicaPomoc[0]) + 1]; // tablica cen
            int[] w = new int[int.Parse(tablicaPomoc[0]) + 1]; // tablica wag

            int[,] tablica = new int[n + 1, W + 1];

            MyStack myStack = new MyStack(n);

            foreach (string linia2 in File.ReadLines(@"D:\Michal\in0302.txt").Skip(1))
            {
                string[] pomoc = linia2.Split(' ');
                p[arg] = int.Parse(pomoc[0]);
                w[arg] = int.Parse(pomoc[1]);
                arg++;
            }

            void policzPlecak(int n, int W)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= W; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            tablica[i, j] = 0;
                        }
                        else
                        {
                            if (w[i] <= j)
                            {
                                tablica[i, j] = Math.Max(tablica[i - 1, j - w[i]] + p[i], tablica[i - 1, j]);
                            }
                            else
                            {
                                tablica[i, j] = tablica[i - 1, j];
                            }
                        }
                    }
                }

            }

            void wypiszWzieteElementy(int i, int j)
            {
                bool czyDodanoNaStos = false;
                if (i == 0)
                {
                    myStack.ToString();
                    return;
                }
                if (w[i] <= j && tablica[i - 1, j - w[i]] + p[i] == tablica[i, j])
                {
                    myStack.Push(i);
                    czyDodanoNaStos = true;
                    wypiszWzieteElementy(i - 1, j - w[i]);
                }
                if (czyDodanoNaStos)
                    myStack.Pop();
                if (tablica[i - 1, j] == tablica[i, j])
                {
                    wypiszWzieteElementy(i - 1, j);
                }
                return;
            }

            policzPlecak(n, W);
            wypiszWzieteElementy(n, W);
        }
    }
}
