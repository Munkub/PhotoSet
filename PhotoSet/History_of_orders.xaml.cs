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
using System.Data;
using System.Data.SqlClient;
using PhotoSet._BDPractosPhotoset_UP_DataSetTableAdapters;

namespace PhotoSet
{
    /// <summary>
    /// Логика взаимодействия для History_of_orders.xaml
    /// </summary>
    public partial class History_of_orders : Window
    {
        ORDERSTableAdapter orders = new ORDERSTableAdapter();
        private int _iduser; 
        public History_of_orders(int iduser)
        {
            InitializeComponent();
            //OrdersDG.ItemsSource = orders.GetData();
            this._iduser = iduser;
            FullDataGrid();

        }
        private void FullDataGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_ORDERS", typeof(string));
            dt.Columns.Add("ID_THINGS", typeof(string));
            dt.Columns.Add("ID_PHOTOGRAPHES", typeof(string));
            dt.Columns.Add("ID_USERS", typeof(string));
            dt.Columns.Add("COUNT", typeof(string));
            dt.Columns.Add("ID_PREMISES", typeof(string));
            dt.Columns.Add("PRICE", typeof(string));
            dt.Columns.Add("DATE", typeof(string));

            foreach (var order in orders.GetData())
            {
                if (order.ID_USERS == _iduser)
                {
                    dt.Rows.Add(order.ID_ORDERS, order.ID_THINGS, order.ID_PHOTOGRAPHERS, order.COUNT, order.ID_PREMISES, order.PRICE, order.DATE);
                }
            }
            OrdersDG.ItemsSource = dt.DefaultView;
        }
        
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            LichKabinet menu = new LichKabinet(_iduser);
            menu.Show();
            this.Close();
        }
    }
}
