using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : Window
    {
        THINGSTableAdapter thing = new THINGSTableAdapter();
        public Goods()
        {
            InitializeComponent();
            GoodsDG.ItemsSource = thing.GetData();
        }

        private void InsertBt_Click(object sender, RoutedEventArgs e)
        {
            thing.InsertQuery(NameTbx.Text, int.Parse(PriceTbx.Text), int.Parse(CountTbx.Text));
            Goods refresh = new Goods();
            refresh.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (GoodsDG.SelectedItem as DataRowView).Row[0];
            thing.UpdateQuery(NameTbx.Text, int.Parse(PriceTbx.Text), int.Parse(CountTbx.Text), Convert.ToInt32(id));
            Goods refresh = new Goods();
            refresh.Show();
            this.Close();
        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            Manager_menu menu = new Manager_menu();
            menu.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (GoodsDG.SelectedItem as DataRowView).Row[0];
            thing.DeleteQuery(Convert.ToInt32(id));

            Goods refresh = new Goods();
            refresh.Show();
            this.Close();
        }
    }
}
