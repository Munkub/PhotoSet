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
    /// Логика взаимодействия для PhotographersClient.xaml
    /// </summary>
    public partial class PhotographersClient : Window
    {
        PHOTOGRAPHERSTableAdapter photog = new PHOTOGRAPHERSTableAdapter();
        private int _iduser;
        public PhotographersClient(int iduser)
        {
            InitializeComponent();
            PhotograDG.ItemsSource = photog.GetData();
            this._iduser = iduser;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            LichKabinet menu = new LichKabinet(_iduser);
            menu.Show();
            this.Close();
        }
    }
}
