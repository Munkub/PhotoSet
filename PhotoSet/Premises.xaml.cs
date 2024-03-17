using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для Premises.xaml
    /// </summary>
    public partial class Premises : Window
    {
        PREMISESTableAdapter premice = new PREMISESTableAdapter();
        public Premises()
        {
            InitializeComponent();
            PremisesDG.ItemsSource = premice.GetData();
        }

        private void InsertBt_Click(object sender, RoutedEventArgs e)
        {
            premice.InsertQuery(NumberTbx.Text, SizeTbx.Text);
            Premises refresh = new Premises();
            refresh.Show();
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (PremisesDG.SelectedItem as DataRowView).Row[0];
            premice.UpdateQuery(NumberTbx.Text, SizeTbx.Text, Convert.ToInt32(id));
            Premises refresh = new Premises();
            refresh.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (PremisesDG.SelectedItem as DataRowView).Row[0];
            premice.DeleteQuery(Convert.ToInt32(id));
            Premises refresh = new Premises();
            refresh.Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager_menu menu = new Manager_menu();
            menu.Show();
            this.Close();
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {

            var id = (PremisesDG.SelectedItem as DataRowView).Row[0];
            var fileName = $"C:\\Users\\twoz1\\prac\\Помещение №{id}.txt";

            var dt = (PremisesDG.SelectedItem as DataRowView).Row[1];

            var dt1 = (PremisesDG.SelectedItem as DataRowView).Row[2];

            File.WriteAllText(fileName, $"\t Помещение №{id} \nНомер: " + id + "\nНомер студии: " + dt + "\nРазмер: " + dt1 + "");

        }
    }
}
