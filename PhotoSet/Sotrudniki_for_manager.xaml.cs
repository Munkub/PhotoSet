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
    /// Логика взаимодействия для Sotrudniki_for_manager.xaml
    /// </summary>
    public partial class Sotrudniki_for_manager : Window
    {
        USERSTableAdapter users = new USERSTableAdapter();
        ROLESTableAdapter role = new ROLESTableAdapter();
        public Sotrudniki_for_manager()
        {
            InitializeComponent();

            var user = users.GetData().Rows;
            
            for (int i = 0; i < user.Count; i++)
            {
                int us = Convert.ToInt32(user[i][3].ToString());
                if (us == 1 )
                {
                    var RolesData = users.GetData();

                    var dataView = new DataView(RolesData);
                    dataView.RowFilter = $"ID_ROLE = 1";
                    PhotogrDG.ItemsSource = dataView;
                }
            }

            var roles = role.GetData().Rows;           // фильтр по роля
                                                      
            for (int i = 0; i < roles.Count; i++)
            {
                int us = Convert.ToInt32(roles[i][0].ToString());
                if (us == 1 )
                {
                    var RolesData = role.GetData();

                   var dataView = new DataView(RolesData);
                    dataView.RowFilter = $"ID_ROLE = 1";
                   RoleCbx.ItemsSource = dataView;
                    RoleCbx.DisplayMemberPath = "ID_ROLE";
                }
            }
        }

        private void InsertBt_Click(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(PasswordTbx.Text, LoginTbx.Text, int.Parse(RoleCbx.Text), NameTbx.Text, SurnameTbx.Text, PasswordTbx.Text, ContactTbx.Text);
            RoleCbx.ItemsSource = role.GetData();
            Sotrudniki_for_manager refresh = new Sotrudniki_for_manager();
            refresh.Show();
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (PhotogrDG.SelectedItem as DataRowView).Row[0];
            users.UpdateQuery(PasswordTbx.Text, LoginTbx.Text, int.Parse(RoleCbx.Text), NameTbx.Text, SurnameTbx.Text, PatronymicTbx.Text, ContactTbx.Text, Convert.ToInt32(id));

            Sotrudniki_for_manager refresh = new Sotrudniki_for_manager();
            refresh.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (PhotogrDG.SelectedItem as DataRowView).Row[0];
            users.DeleteQuery(Convert.ToInt32(id));
            Sotrudniki_for_manager refresh = new Sotrudniki_for_manager();
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
