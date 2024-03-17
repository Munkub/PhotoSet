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
    /// Логика взаимодействия для Photoraphers.xaml
    /// </summary>
    public partial class Photoraphers : Window
    {
        PHOTOGRAPHERSTableAdapter fotogr = new PHOTOGRAPHERSTableAdapter();
        ROLESTableAdapter role = new ROLESTableAdapter();
        public Photoraphers()
        {
            InitializeComponent();
            PhotogrDG.ItemsSource = fotogr.GetData();
            var roles = role.GetData().Rows;           // фильтр по роля

            for (int i = 0; i < roles.Count; i++)
            {
                int us = Convert.ToInt32(roles[i][0].ToString());
                if (us == 3)
                {
                    var RolesData = role.GetData();

                    var dataView = new DataView(RolesData);
                    dataView.RowFilter = $"ID_ROLE = 3";
                    RoleCbx.ItemsSource = dataView;
                    RoleCbx.DisplayMemberPath = "ID_ROLE";
                }
            }
        }

        private void InsertBt_Click(object sender, RoutedEventArgs e)
        {
            fotogr.InsertQuery(NameTbx.Text, SurnameTbx.Text, PatronymicTbx.Text,ContacTbx.Text, int.Parse(RoleCbx.Text));  //(PasswordTbx.Text, LoginTbx.Text, int.Parse(RoleCbx.Text), NameTbx.Text, SurnameTbx.Text, PasswordTbx.Text, ContactTbx.Text);
            RoleCbx.ItemsSource = role.GetData();
            Photoraphers refresh = new Photoraphers();
            refresh.Show();
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (PhotogrDG.SelectedItem as DataRowView).Row[0];
            fotogr.UpdateQuery(NameTbx.Text, SurnameTbx.Text, PatronymicTbx.Text, ContacTbx.Text,int.Parse(RoleCbx.Text) ,Convert.ToInt32(id));     //NumberTbx.Text, SizeTbx.Text, Convert.ToInt32(id)
            Photoraphers refresh = new Photoraphers();
            refresh.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (PhotogrDG.SelectedItem as DataRowView).Row[0];
            fotogr.DeleteQuery(Convert.ToInt32(id));
            Photoraphers refresh = new Photoraphers();
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
