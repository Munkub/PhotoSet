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
    /// Логика взаимодействия для Polzovateli.xaml
    /// </summary>
    public partial class Polzovateli : Window
    {
        USERSTableAdapter users = new USERSTableAdapter();
        ROLESTableAdapter role = new ROLESTableAdapter();
        public Polzovateli()
        {
            InitializeComponent();
            var user = users.GetData().Rows;

            for (int i = 0; i < user.Count; i++)
            {
                int us = Convert.ToInt32(user[i][3].ToString());
                if (us == 2)
                {
                    var RolesData = users.GetData();

                    var dataView = new DataView(RolesData);
                    dataView.RowFilter = $"ID_ROLE = 2";
                    UsersDG.ItemsSource = dataView;
                }
            }

            var roles = role.GetData().Rows;           // фильтр по роля

            for (int i = 0; i < roles.Count; i++)
            {
                int us = Convert.ToInt32(roles[i][0].ToString());
                if (us == 2)
                {
                    var RolesData = role.GetData();

                    var dataView = new DataView(RolesData);
                    dataView.RowFilter = $"ID_ROLE = 2";
                    RoleCbx.ItemsSource = dataView;
                    RoleCbx.DisplayMemberPath = "ID_ROLE";
                }
            }
        }

        private void InsertBt_Click(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(PasswordTbx.Text, LoginTbx.Text, int.Parse(RoleCbx.Text), NameTbx.Text, SurnameTbx.Text, PasswordTbx.Text, ContacTbx.Text);
            RoleCbx.ItemsSource=role.GetData();
            Polzovateli refresh = new Polzovateli();
            refresh.Show();
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (UsersDG.SelectedItem as DataRowView).Row[0];
            users.UpdateQuery(PasswordTbx.Text, LoginTbx.Text, int.Parse(RoleCbx.Text), NameTbx.Text, SurnameTbx.Text, PatronymicTbx.Text, ContacTbx.Text, Convert.ToInt32(id));

            Polzovateli refresh = new Polzovateli();
            refresh.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (UsersDG.SelectedItem as DataRowView).Row[0];
            users.DeleteQuery(Convert.ToInt32(id));
            Polzovateli refresh = new Polzovateli();
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
