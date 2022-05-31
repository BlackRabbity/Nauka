using System;
using System.Collections.Generic;
using System.Text;

namespace Silnie_spojne_skladowe
{
    public class pair
    {
        public int a, b;
        public pair(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void wypisz()
        {
            Console.WriteLine("a=" + a);
            Console.WriteLine("b=" + b);
        }

    }
}
