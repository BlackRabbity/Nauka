using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Plecakowy
{
    public class MyStack
    {
        int n;
        int[] tab;
        int aktualnyRozmiar = 0;
        public MyStack(int n)
        {
            this.n = n;
            tab = new int[n];
        }
        public void Push(int x)
        {
            tab[aktualnyRozmiar++] = x;
        }
        public void Pop()
        {
            if (aktualnyRozmiar == 0)
                throw new System.InvalidOperationException();
            --aktualnyRozmiar;
        }
        public override string ToString()
        {
            for (int i = aktualnyRozmiar - 1; i >= 0; --i)
            {
                Console.Write(tab[i] + " ");
            }
            Console.WriteLine();
            return "";
        }

    }
}
