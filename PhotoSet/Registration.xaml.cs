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
using MySql.Data.MySqlClient;
using PhotoSet._BDPractosPhotoset_UP_DataSetTableAdapters;

namespace PhotoSet
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        USERSTableAdapter users = new USERSTableAdapter();
        ROLESTableAdapter role = new ROLESTableAdapter();

        public Registration()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            var rolesData = role.GetData();
            var dataView = new DataView(rolesData);
            dataView.RowFilter = "ID_ROLE = 1 OR ID_ROLE = 2";
            RoleIDCombo.ItemsSource = dataView;
            RoleIDCombo.DisplayMemberPath = "ID_ROLE";
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            CloseRegistration();
        }

        private void Zareg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                users.InsertQuery(PasswordTbx.Text, LoginTbx.Text, int.Parse(RoleIDCombo.Text), Name.Text, Surname.Text, Patronymic.Text, Contact_Information.Text);
                CloseRegistration();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации пользователя: " + ex.Message);
            }
        }

        private void CloseRegistration()
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
