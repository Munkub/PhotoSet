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
using System.Data.SqlClient;
using PhotoSet._BDPractosPhotoset_UP_DataSetTableAdapters;
using System.IO;

namespace PhotoSet
{
    /// <summary>
    /// Логика взаимодействия для Zapis_na_fotoset.xaml
    /// </summary>
    public partial class Zapis_na_fotoset : Window
    {
        ORDERSTableAdapter orders = new ORDERSTableAdapter();
        USERSTableAdapter users = new USERSTableAdapter();
        PREMISESTableAdapter premis = new PREMISESTableAdapter();
        PHOTOGRAPHERSTableAdapter adapter = new PHOTOGRAPHERSTableAdapter();
        THINGSTableAdapter thing = new THINGSTableAdapter();
        public Zapis_na_fotoset()
        {
            InitializeComponent();
            OrdersDG.ItemsSource = orders.GetData().Rows;
            idThingCb.ItemsSource = thing.GetData().Rows;
            idThingCb.DisplayMemberPath = "ID_THINGS";
            idThingCb.SelectedValuePath = "ID_THINGS";
            idFotogrCb.ItemsSource = adapter.GetData().Rows;
            idFotogrCb.DisplayMemberPath = "ID_PHOTOGRAPHERS";
            idFotogrCb.SelectedValuePath = "ID_PHOTOGRAPHERS";
            idUserCb.ItemsSource = users.GetData().Rows;
            idUserCb.DisplayMemberPath = "ID_USERS";
            idUserCb.SelectedValuePath = "ID_USERS";
            idPremisCb.ItemsSource = premis.GetData().Rows;
            idPremisCb.DisplayMemberPath = "ID_PREMISES";
            idPremisCb.SelectedValuePath = "ID_PREMISES";

        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            orders.InsertQuery(int.Parse(idThingCb.Text), int.Parse(idFotogrCb.Text), int.Parse(idUserCb.Text), int.Parse(CountTbx.Text), int.Parse(idPremisCb.Text), int.Parse(PriceTbx.Text), DateTbx.Text);
            Zapis_na_fotoset refresh = new Zapis_na_fotoset();
            refresh.Show();
            this.Close();
        }

        private void UpdatetBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (OrdersDG.SelectedItem as DataRowView).Row[0];
            orders.UpdateQuery(int.Parse(idThingCb.Text), int.Parse(idFotogrCb.Text), int.Parse(idUserCb.Text), int.Parse(CountTbx.Text), int.Parse(idPremisCb.Text), int.Parse(PriceTbx.Text), DateTbx.Text, Convert.ToInt32(id));
            Zapis_na_fotoset refresh = new Zapis_na_fotoset();
            refresh.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (OrdersDG.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(Convert.ToInt32(id));
            Zapis_na_fotoset refresh = new Zapis_na_fotoset();
            refresh.Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager_menu menu = new Manager_menu(); 
            menu.Show();
            this.Close();
        }

    }
}
