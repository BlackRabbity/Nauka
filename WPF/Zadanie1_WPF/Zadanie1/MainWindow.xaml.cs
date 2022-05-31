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

namespace Zadanie1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Maszyna maszyna;
        public MainWindow()
        {
            InitializeComponent();
            maszyna = new Maszyna();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            komunikat.Text = null;
            if (pole_tekstowe.Text == null || pole_tekstowe.Text == "")
            {
                MessageBox.Show("Error");
                return;
            }
            maszyna.Dodaj(pole_tekstowe.Text);
            komunikat.Text = "DODANO: " + pole_tekstowe.Text;
            pole_wynik.Text = null;
            pole_wynik.Text = maszyna.Zawartosc();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            komunikat.Text = null;
            if (maszyna.Pusta() == false)
            {
                komunikat.Text = "WYJĘTO: "+ maszyna.Wyjmij();
            }else
            {
                MessageBox.Show("Nie ma więcej losów");
                return;
            }
            pole_wynik.Text = null;
            pole_wynik.Text = maszyna.Zawartosc();

        }
    }
}
