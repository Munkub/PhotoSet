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
    /// Логика взаимодействия для LichKabinet.xaml
    /// </summary>
    public partial class LichKabinet : Window
    {
        USERSTableAdapter adapter = new USERSTableAdapter();
        private int _iduser;
        public LichKabinet(int iduser)
        {

            InitializeComponent();
            _iduser = iduser;
        }

        private void LogOutLichKab_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
        private void HistorisOrderLichKab_Click(object sender, RoutedEventArgs e)
        {
            History_of_orders history = new History_of_orders(_iduser);
            history.Show();
            this.Close();
        }

        private void ThingsBtn_Click(object sender, RoutedEventArgs e)
        {
            ThingsClients things = new ThingsClients(_iduser);
            things.Show();
            this.Close();   
        }

        private void PremisesBtn_Click(object sender, RoutedEventArgs e)
        {
            PremisesClient premis = new PremisesClient(_iduser);
            premis.Show();
            this.Close();
        }

        private void PhotographsBtn_Click(object sender, RoutedEventArgs e)
        {
            PhotographersClient photogr = new PhotographersClient(_iduser);
            photogr.Show();
            this.Close();
        }
    }
}
