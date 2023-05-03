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

namespace DimitrovaM_FinalProject2023
{
    /// <summary>
    /// Interaction logic for Menu2.xaml
    /// </summary>
    public partial class Menu2 : Window
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private void mydata_Click(object sender, RoutedEventArgs e)
        {
            MyData2 m = new MyData2();
            m.Show();
            this.Close();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            Order2 o = new Order2();
            o.Show();
            this.Close();
        }
    }
}
