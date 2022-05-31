using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x;

        double y = 0.50;
        string A = "A4";
        string papier = "zwykły papier";
        string gramatura = "120 g/m²";
        string druk = "druk kolor";
        string termintxt = "";
        int rabat = 0;

        double pomocGram = 2;
        double pomocDruk = 1.3;
        bool pomocTermin = false;
        double kolorpomoc = 1;
        double cena;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void wypisz()
        {
            double pom;
            if(pomocTermin == false)
            {
                pom = x * y * pomocGram * pomocDruk * kolorpomoc;
            }
            else
            {
                pom = (x * y * pomocGram * pomocDruk * kolorpomoc) + 15;
            }
            wynik.Clear();
            wynik.AppendText("Przedmiot zamówienia: " + x + " szt.," + " format " + A + ", "+ papier + ", " + gramatura + ", " + druk + " " + termintxt + "\n"
                  + "Cena przed rabatem: " + String.Format("{0:0.00}", pom) + "zł" + "\n"
                  + "Naliczony rabat: " + rabat + "%" + "\n"
                  + "Cena po rabacie: " + String.Format("{0:0.00}", pom * (100 - rabat)/100) + "zł");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            rabat = 0;
            if(naklad.Text == "")
            {
                x = 0;
            }else
            {
                try
                {
                    x = int.Parse(naklad.Text);
                    rabat = x / 100;
                    if (rabat > 10)
                        rabat = 10;
                } catch (Exception)
                {
                    MessageBox.Show("Zła wartość");
                    naklad.Clear();
                    return;
                }
            }
            wypisz();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(format != null)
            {
                y = 0.20;
                if (formatslider.Value == 0)
                {
                    A = "A5";
                    format.Content = A + "-cena " + y*100 + "gr/szt.";
                }
                else if (formatslider.Value == 1)
                {
                    A = "A4";
                    y = (double)(y * 2.5);
                    format.Content = A + "-cena " + y*100 + "gr/szt.";
                }
                else if (formatslider.Value == 2)
                {
                    A = "A3";
                    y = (double)(y * Math.Pow(2.5,2));
                    format.Content = A + "-cena " + String.Format("{0:0.00}",y) + "zł/szt.";
                }
                else if (formatslider.Value == 3)
                {
                    A = "A2";
                    y = (double)(y * Math.Pow(2.5, 3));
                    format.Content = A + "-cena " + String.Format("{0:0.00}", y) + "zł/szt.";

                }
                else if (formatslider.Value == 4)
                {
                    A = "A1";
                    y = (double)(y * Math.Pow(2.5, 4));
                    format.Content = A + "-cena " + String.Format("{0:0.00}", y) + "zł/szt.";
                }
                else if (formatslider.Value == 5)
                {
                    A = "A0";
                    y = (double)(y * Math.Pow(2.5, 5));
                    format.Content = A + "-cena " + String.Format("{0:0.00}", y) + "zł/szt.";
                }
                wypisz();
            }
        }

        private void kolor_papier_Checked(object sender, RoutedEventArgs e)
        {
            kolorpomoc = 1;
            if(kolor_papier.IsChecked == true)
            {
                kolory.IsEnabled = true;
                kolorpomoc = 1.5;
            }else if (kolor_papier.IsChecked == false)
            {

                kolory.IsEnabled = false;
                kolory.SelectedItem = null;
                papier = "papier zwykły";
            }
            wypisz();
        }

        private void kolory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (kolory.SelectedIndex == 0)
            {
                papier = "papier żółty";
            }
            else if (kolory.SelectedIndex == 1)
            {
                papier = "papier zielony";
            }
            else if (kolory.SelectedIndex == 2)
            {
                papier = "papier niebieski";

            }
            wypisz();
        }
        private void Klik(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton cbx in gram.Children)
            {
                if (cbx.Name == "gram1" && cbx.IsChecked == true)
                {
                    gramatura = "80 g/m²";
                    pomocGram = 1;
                }
                else if (cbx.Name == "gram2" && cbx.IsChecked == true)
                {
                    gramatura = "120 g/m²";
                    pomocGram = 2;
                    
                }
                else if (cbx.Name == "gram3" && cbx.IsChecked == true)
                {
                    gramatura = "200 g/m²";
                    pomocGram = 2.5;
                }
                else if (cbx.Name == "gram4" && cbx.IsChecked == true)
                {
                    gramatura = "240 g/m²";
                    pomocGram = 3;
                }
            }
            wypisz();
        }

        private void Klik2(object sender, RoutedEventArgs e)
        {
            druk = null;
            pomocDruk = 1;
            foreach (CheckBox cbx in wydruk.Children)
            {
                if (cbx.Name == "wyd1" && cbx.IsChecked == true)
                {
                    druk = druk + " druk kolor";
                    pomocDruk = pomocDruk * 1.3;
                }
                else if (cbx.Name == "wyd2" && cbx.IsChecked == true)
                {
                    druk = druk + " druk dwustronny";
                    pomocDruk = pomocDruk * 1.5;

                }
                else if (cbx.Name == "wyd3" && cbx.IsChecked == true)
                {
                    druk = druk + " lakier UV";
                    pomocDruk = pomocDruk * 1.2;
                }
            }
            wypisz();
        }
        private void Klik3(object sender, RoutedEventArgs e)
        {
            termintxt = "";
            pomocTermin = false;
            foreach (RadioButton cbx in termin.Children)
            {
                if (cbx.Name == "term2" && cbx.IsChecked == true)
                {
                    pomocTermin = true;
                    termintxt = "Termin - przyśpieszony";
                }
            }
            wypisz();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zamówienie zostało złożone");
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
