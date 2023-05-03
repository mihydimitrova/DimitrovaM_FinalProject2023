using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DimitrovaM_FinalProject2023
{
    /// <summary>
    /// Interaction logic for Order2.xaml
    /// </summary>
    public partial class Order2 : Window
    {
        public Order2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");
                sqlCon.Open();
                string query = "Insert into Orders (Email, Type, Fabric, Comments) values('" + this.email.Text + "','" + this.type.Text + "','" + this.fabric.Text + "','" + this.comments.Text + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Account created successfully");
                MainWindow sign = new MainWindow();
                sqlCon.Close();
            }
            catch (Exception a)
            {


            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Menu2 o = new Menu2();
            o.Show();
            this.Close();
        }
    }
}
