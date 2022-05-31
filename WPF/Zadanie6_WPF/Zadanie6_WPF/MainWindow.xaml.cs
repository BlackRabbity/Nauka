using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Zadanie6_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Collection<Person> People { get; } = new ObservableCollection<Person>();

        public List<string> Regiony = new List<string>();
        public MainWindow()
        {
            Regiony.Add("Warszawa");
            Regiony.Add("Białystok");
            Regiony.Add("Sokółka");
            Regiony.Add("Czarna Białostocka");
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ludzie.ItemsSource = People;
            region.ItemsSource = Regiony;
        }

        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ludzie.SelectedIndex != -1)
            {
                People[ludzie.SelectedIndex].EMail = null ;
                People[ludzie.SelectedIndex].KwotaWplaty = 0;
                People[ludzie.SelectedIndex].Region = null;
                People[ludzie.SelectedIndex].PoziomDostepu = 0;
                mail.Text = null;
                kwota.Text = null;
                region.Text = null;
                pozDost.Value = 0;
            }
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            szczegoly.IsEnabled = true;
            People.Add(new Person());
            ludzie.SelectedIndex = People.Count - 1;
            imie.Text = "Imie";
            imie.SelectAll();
            imie.Focus();
        }

        private void Usun(object sender, RoutedEventArgs e)
        {
            People.RemoveAt(ludzie.SelectedIndex);
            szczegoly.IsEnabled = false;
            if (People.Count == 0)
            {
                check.IsChecked = false;
            }
        }

        private void ludzie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            szczegoly.IsEnabled = true;
            if (ludzie.SelectedIndex != -1)
            {
                if (People[ludzie.SelectedIndex].EMail != null || (People[ludzie.SelectedIndex].KwotaWplaty != 0 || (People[ludzie.SelectedIndex].Region != null || (People[ludzie.SelectedIndex].PoziomDostepu != 0))))
                {
                    check.IsChecked = true;
                }
                else
                {
                    check.IsChecked = false;
                }
            }
        }
    }
}
