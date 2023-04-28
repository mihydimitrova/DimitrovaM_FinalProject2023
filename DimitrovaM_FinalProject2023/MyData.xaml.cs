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
    /// Interaction logic for MyData.xaml
    /// </summary>
    public partial class MyData : Window
    {
        public MyData()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {



            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");


            try
            {
                sqlCon.Open();
                string query = "Select * from TailoringData";
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");
                sqlCon.Open();
                string query = "Insert into TailoringData (Email, Height, TopSize, BottomSize, Chest, ArmsWidth, Hips, Waist, Legs, Shoulders) values('" + this.email.Text + "','" + this.height.Text + "','" + this.topssize.Text + "','" + this.bottomssize.Text + "','" + this.chest.Text + "','" + this.arms.Text + "','" + this.hips.Text + "','" + this.waist.Text + "','" + this.legs.Text + "','" + this.shoulders.Text + "')";
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");
            try
            {
                sqlCon.Open();
                String query = "UPDATE Tailoring set Height = '" + this.height.Text + ", TopSize = '" + this.topssize.Text + ", BottomSize = '" + this.bottomssize.Text + ", Chest = '" + this.chest.Text + ", ArmsWidth = '" + this.arms.Text + ", Hips = '" + this.hips.Text + ", Waist = '" + this.waist.Text + ", Legs = '" + this.legs.Text + ", Shoulders = '" + this.shoulders.Text + "'WHERE Email= '" + this.email.Text + "'";
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
                string query = "DELETE from TailoringData WHERE Email = '" + this.email.Text + "'";
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
    }
}
