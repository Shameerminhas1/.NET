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

namespace Event_System
{
    /// <summary>
    /// Interaction logic for DashbordES.xaml
    /// </summary>
    public partial class DashbordES : Window
    {
        public DashbordES()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void About_btn_Click(Object sender,RoutedEventArgs e)
        {
            AboutData aboutData = new AboutData();
            this.Close();
            aboutData.Show();
        }

        private void Add_btn_Click(Object sender,RoutedEventArgs e)
        {
            DataPick dataPick = new DataPick();
            this.Close();
            dataPick.Show();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            rights RIGHTS = new rights();
            this.Close();
            RIGHTS.Show();
        }

    }
}
