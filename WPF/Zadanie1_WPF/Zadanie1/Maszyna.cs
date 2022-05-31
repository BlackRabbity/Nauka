using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Maszyna
    {
        List<string> napisy;
        public Maszyna()
        {
            napisy = new List<string>();
        }

        public void Dodaj(string napis) 
        {
            napisy.Add(napis);
        }
        public string Wyjmij()
        {
            int x = napisy.Count;
            Random r = new Random();
            int y = r.Next(x);
            string a = napisy[y];
            napisy.RemoveAt(y);
            return a;
        }
        public bool Pusta()
        {
            if(napisy.Count > 0)
            {
                return false;
            }
            return true;
        }
        public string Zawartosc()
        {
            string pom = " ";
            foreach(var a in napisy)
            {
                pom += a + ", ";
            }
            return pom;
        }
    }
}
