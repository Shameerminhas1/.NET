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
    /// Interaction logic for Question.xaml
    /// </summary>
    public partial class Question : Window
    {
        public Question()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query_1 = Query_txt.Text;
            if (query_1 == "Yes" || query_1 == "yes" || query_1 == "y" || query_1 == "Y" || query_1 == "YES")
            {
                Options options = new Options();
                this.Close();
                options.Show();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           user user =  new user();
            this.Close();
            user.Show();
        }
    }
}
