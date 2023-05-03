using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimitrovaM_FinalProject2023
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");


            try
            {
                sqlCon.Open();
                string query = "Select * from Orders";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataGrid_.ItemsSource = dt.AsDataView();
                adapter.Update(dt);

                MessageBox.Show("Successful loading");
                sqlCon.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");
            try
            {
                sqlCon.Open();
                String query = "UPDATE Orders set Email = '" + this.email.Text + ", [Type] = '" + this.type.Text + ", Fabric = '" + this.fabric.Text +  ", Comments = '" + this.comments.Text + "'WHERE ID = '" + this.id.Text + "'";
                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                //catches any mistake
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True"); try
            {
                sqlCon.Open();
                string query = "DELETE from Orders WHERE ID = '" + this.id.Text + "'";
                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted!");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                //catches any mistake
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");
                sqlCon.Open();
                string query = "Insert into Orders (Email, Type, Fabric, Comments) values('" + this.email.Text + "','" + this.type.Text + "','" + this.fabric.Text + "')";
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
            Menu o = new Menu();
            o.Show();
            this.Close();
        }
    }
}
