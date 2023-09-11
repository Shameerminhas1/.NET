using System;
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
using static System.Net.Mime.MediaTypeNames;

namespace Event_System
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=CODE-X\\CODEX;Initial Catalog=vpproj;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        //public void show()
        //{
        //    da = new SqlDataAdapter("select * from feedback1", con);
        //    dt = new DataTable();
        //    da.Fill(dt);
        //    grid1.ItemsSource = dt.DefaultView;
        //}


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if the value exists in the reference table
                SqlCommand selectCmd = new SqlCommand("SELECT COUNT(*) FROM event WHERE cnicno = @cnicno", con);
                selectCmd.Parameters.AddWithValue("@cnicno", TEXTB1.Text);
                con.Open();
                int count = (int)selectCmd.ExecuteScalar();
                con.Close();

                if (count == 0)
                {
                    // If the value doesn't exist, throw an exception
                    throw new Exception("Invalid CNIC number.");
                }

                // Insert the record
                SqlCommand insertCmd = new SqlCommand("INSERT INTO feeddbk(cnicno, feedback) VALUES (@cnicno, @feedback)", con);
                insertCmd.Parameters.AddWithValue("@cnicno", TEXTB1.Text);
                insertCmd.Parameters.AddWithValue("@feedback", rich.Text);
                con.Open();
                insertCmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record inserted successfully");
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            rich.Clear();
            TEXTB1.Clear();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         user user = new user();
            this.Close();
            user.Show();
        }

      
    }
}
