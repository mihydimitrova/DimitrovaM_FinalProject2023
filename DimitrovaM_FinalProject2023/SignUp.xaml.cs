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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpGo_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-GFLJDUA; Initial Catalog=tailoring; Integrated Security=True");

            try
            {


                //opening the connection to the db 

                sqlCon.Open();

                //Build our actual query 

                string query = "INSERT INTO SignupTable( [First Name], [Last Name], Email, Password, [Repeat Password]) values('" + this.first.Text + "', '" + this.last.Text + "', '" + this.email.Text + "', '" + this.pass.Password + "', '" + this.reppass.Password + "')";

                //Establish a sql command

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");

                LogIn gf = new LogIn();
                gf.Show();
                this.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon.Close();

            }
        }
    }
}
