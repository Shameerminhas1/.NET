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

namespace Event_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
             
        private void login_Click(object sender, RoutedEventArgs e)
        {
            string username1 = username.Text;
            string password113 = passbox.Password;
            if (username1 == "Irfan" && password113 == "026")
            {
                
                DashbordES dashbordES = new DashbordES();
                this.Close();
                dashbordES.Show();
            }
            else
            {
                MessageBox.Show("Try Again");
                username.Clear();
                passbox.Clear();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rights rights= new rights();
            this.Close();
            rights.Show();
        }
    }
}
