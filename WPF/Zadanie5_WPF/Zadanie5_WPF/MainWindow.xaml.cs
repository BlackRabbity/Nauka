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

namespace Zadanie5_WPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajFilm window = new DodajFilm();
            window.ShowDialog();
            if(window.film != null)
            {
                ListaFilmow.Items.Add(window.film);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DodajFilm window = new DodajFilm();
            Film film = (Film)ListaFilmow.SelectedItem;
            window.nazwatxt.Text = film.tytul;
            window.datatxt.SelectedDate = film.premiera.Date;
            window.opistxt.Text = film.opis;
            window.ShowDialog();
            if (window.film != null)
            {
                int index = ListaFilmow.SelectedIndex;
                film = window.film;
                ListaFilmow.Items.RemoveAt(index);
                ListaFilmow.Items.Insert(index, film);
                UnSelect();
            }
        }

        void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy napewno chcesz usunąć film?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do nothing
            }
            else
            {
                ListaFilmow.Items.RemoveAt(ListaFilmow.SelectedIndex);
                UnSelect();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<Podglad>().FirstOrDefault();

            if (window == null)
            {
                window = new Podglad();
            }
            Film film = (Film)ListaFilmow.SelectedItem;
            window.nazwatxt.Text = film.tytul;
            window.datatxt.Text = film.premiera.ToShortDateString();
            window.opistxt.Text = film.opis;
            window.Show();
            window.Activate();
        }

        private void ListaFilmow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaFilmow.SelectedItem != null)
            {
                podglad.IsEnabled = true;
                usun.IsEnabled = true;
                edytuj.IsEnabled = true;
            }
        }

        private void UnSelect()
        {
            podglad.IsEnabled = false;
            usun.IsEnabled = false;
            edytuj.IsEnabled = false;
        }
    }
}
