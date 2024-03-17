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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        USERSTableAdapter adapter = new USERSTableAdapter();
        public MainWindow()

        {
            InitializeComponent();
            
        }

        private void Voyti_Click(object sender, RoutedEventArgs e)
        {

            var allLogins = adapter.GetData().Rows;
            bool isLoggedIn = false;
            for (int i = 0; i < allLogins.Count; i++)
            { //проверить каждую строку на логин и пароль//
                if (
                    allLogins[i][1].ToString() == LoginTbx.Text &&
                    allLogins[i][2].ToString() == PasswordTbx.Text)
                {
                    int roleid = (int)allLogins[i][3];
                    switch (roleid)
                    {
                        case 1:
                            Manager_menu menu = new Manager_menu();
                            menu.Show();
                            break;
                        case 2:
                            LichKabinet lichn = new LichKabinet((int)allLogins[i][0]);
                            lichn.Show();
                            break;
                    }
                      isLoggedIn = true;
                      break;
                }

            }

            if (!isLoggedIn)
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }


        private void Registration_Click(object sender, RoutedEventArgs e)
        {
           Registration registr = new Registration();
            registr.Show();
            this.Close();
        }

       
    }
}
