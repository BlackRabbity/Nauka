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
using System.Windows.Shapes;

namespace Zadanie5_WPF
{
    /// <summary>
    /// Interaction logic for DodajFilm.xaml
    /// </summary>
    public partial class DodajFilm : Window
    {
        public Film film;
        public DodajFilm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if( nazwatxt != null && !string.IsNullOrWhiteSpace(nazwatxt.Text) && datatxt != null)
            {
                try
                {
                    film = new Film(nazwatxt.Text, datatxt.SelectedDate.Value, opistxt.Text);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Dane są nieprawidłowe");
                }
            } else
            {
                MessageBox.Show("Dane są nieprawidłowe");
            }

        }
    }
}
