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
using PhotoSet._BDPractosPhotoset_UP_DataSetTableAdapters;

namespace PhotoSet
{
    /// <summary>
    /// Логика взаимодействия для Manager_menu.xaml
    /// </summary>
    public partial class Manager_menu : Window
    {
        public Manager_menu()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Goods tovar = new Goods();
            tovar.Show();
            this.Close();
        }

        private void PhotographersBtn_Click(object sender, RoutedEventArgs e)
        {
            Sotrudniki_for_manager sotr = new Sotrudniki_for_manager();
            sotr.Show();
            this.Close();
        }

        private void PremisesBtn_Click(object sender, RoutedEventArgs e)
        {
            Premises prem = new Premises();
            prem.Show();
            this.Close();
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            Polzovateli polz = new Polzovateli();
            polz.Show();
            this.Close();
        }

        private void OrderHistBtn_Click(object sender, RoutedEventArgs e)
        {
            Zapis_na_fotoset zapis = new Zapis_na_fotoset();
            zapis.Show();
            this.Close();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FotogrBtn_Click(object sender, RoutedEventArgs e)
        {
            Photoraphers fotogr = new Photoraphers();
            fotogr.Show();
            this.Close();
        }
    }
}
