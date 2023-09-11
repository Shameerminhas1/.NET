using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for feedrec.xaml
    /// </summary>
    public partial class feedrec : Window
    {
        private static SqlCommand cmd;

        public feedrec()
        {
            InitializeComponent();
        }
        

private void Back_Click(object sender, RoutedEventArgs e)
        {
            DataPick dataPick = new DataPick();
            this.Close();
            dataPick.show();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=CODE-X\\CODEX;Initial Catalog=vpproj;Integrated Security=True";

            // SQL query to retrieve data from your table
            string query = "SELECT * FROM feeddbk";

            // Establish a connection to your database and execute the SQL query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Set the DataGrid's ItemsSource to the DataTable to display the data
                DG.ItemsSource = dataTable.DefaultView;
            }
        }
     
    }
}
