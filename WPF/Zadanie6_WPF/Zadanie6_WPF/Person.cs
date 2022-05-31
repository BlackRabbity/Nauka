using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6_WPF
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string imie;
        private string nazwisko;
        private string eMail;
        private decimal kwotaWplaty;
        private string region;
        private int poziomDostepu;

        public string Imie
        {
            get { return imie; }
            set { imie = value; OnPropertyChanged("NameAndMail"); }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; OnPropertyChanged("NameAndMail"); }
        }
        public string EMail
        {
            get { return eMail; }
            set { eMail = value; OnPropertyChanged("NameAndMail"); }
        }
        public decimal KwotaWplaty
        {
            get { return kwotaWplaty; }
            set { kwotaWplaty = value; OnPropertyChanged("NameAndMail"); }
        }
        public string Region
        {
            get { return region; }
            set { region = value; OnPropertyChanged("NameAndMail"); }
        }
        public int PoziomDostepu
        {
            get { return poziomDostepu; }
            set { poziomDostepu = value; OnPropertyChanged("NameAndMail"); }
        }

        public Person(string Imie, string Nazwisko, string EMail, decimal KwotaWplaty, string Region, int PoziomDostepu)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.EMail = EMail;
            this.KwotaWplaty = KwotaWplaty;
            this.Region = Region;
            this.PoziomDostepu = PoziomDostepu;
        }
        public Person(string Imie, string Nazwisko)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
        }
        public Person()
        {
        }

        public override string ToString()
        {
            if (EMail != null)
            return Imie + " " + Nazwisko + "(" + EMail + ")";
            return Imie + " " + Nazwisko;
        }

        public string NameAndMail
        {
            get
            {
                if (EMail != null)
                return Imie + " " + Nazwisko + "(" + EMail + ")";
                return Imie + " " + Nazwisko;
            }
        }
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}