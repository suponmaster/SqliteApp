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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqliteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(fistNametxt.Text, lastNametxt.Text, emailtxt.Text);
            MessageBox.Show("Data Add Success");
            fistNametxt.Text = "";
            lastNametxt.Text = "";
            emailtxt.Text = "";
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            string CustomersData = "";
            foreach (string data in DataAccess.GetData())
            {
                CustomersData = CustomersData + data + "\n";
            }
            MessageBox.Show(CustomersData, "Data Info");
        }
    }
}
