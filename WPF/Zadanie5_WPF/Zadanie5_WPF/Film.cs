using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_WPF
{
    public class Film
    {
        public string tytul;
        public DateTime premiera;
        public string opis;

        public Film(string tytul, DateTime premiera, string opis)
        {
            this.tytul = tytul;
            this.premiera = premiera;
            this.opis = opis;
        }

        public override string ToString()
        {
            return tytul;
        }
    }
}
