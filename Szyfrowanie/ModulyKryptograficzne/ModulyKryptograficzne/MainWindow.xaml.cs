using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ModulyKryptograficzne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+-");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (wej1.Text == "")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }else
            {
                RailFence railFence = new RailFence();
                wynik1.Text = railFence.Szyfruj(wej1.Text, Int32.Parse(n1.Text));
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (wej2.Text == "")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }
            else
            {
                RailFence railFence = new RailFence();
                wynik2.Text = railFence.Deszyfruj(wej2.Text, Int32.Parse(n2.Text));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (wej3.Text == "")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }
            else
            {
                PrzedstawieniaMacierzoweA przedMacA = new PrzedstawieniaMacierzoweA();
                wynik3.Text = przedMacA.Szyfruj(wej3.Text, n3.Text);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (wej4.Text == "")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }
            else
            {
                PrzedstawieniaMacierzoweA przedMacA = new PrzedstawieniaMacierzoweA();
                wynik4.Text = przedMacA.Deszyfruj(wej4.Text, n4.Text);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (wej5.Text == "")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }
            else
            {
                PrzedstawieniaMacierzoweB przedMacB = new PrzedstawieniaMacierzoweB();
                wynik5.Text = przedMacB.Szyfruj(wej5.Text, n5.Text);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (wej6.Text == "")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }
            else
            {
                PrzedstawieniaMacierzoweB przedMacB = new PrzedstawieniaMacierzoweB();
                wynik6.Text = przedMacB.Deszyfruj(wej6.Text, n6.Text);
            }
        }
    }
}
