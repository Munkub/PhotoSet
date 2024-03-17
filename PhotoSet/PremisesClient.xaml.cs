using PhotoSet._BDPractosPhotoset_UP_DataSetTableAdapters;
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

namespace PhotoSet
{
    /// <summary>
    /// Логика взаимодействия для PremisesClient.xaml
    /// </summary>
    public partial class PremisesClient : Window
    {  
        PREMISESTableAdapter premis = new PREMISESTableAdapter();
        private int _iduser;
        public PremisesClient(int iduser)
        {
            InitializeComponent();
            _iduser = iduser;
            PremisesDG.ItemsSource = premis.GetData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            LichKabinet menu = new LichKabinet(_iduser);
            menu.Show();
            this.Close();
        }
    }
}
