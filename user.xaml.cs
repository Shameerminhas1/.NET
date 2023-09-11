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

namespace Event_System
{
    /// <summary>
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Window
    {
        public user()
        {
            InitializeComponent();
        }
        
        private void SearchByID_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textbox.Text, out int cnicno))
            {
                {
                    string connectionString = "Data Source=CODE-X\\CODEX;Initial Catalog=vpproj;Integrated Security=True"; 
                    string query = "SELECT * FROM event WHERE cnicno = @cnicno"; 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cnicno", cnicno.ToString());

                        try
                        {
                            connection.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            myDataGrid.ItemsSource = dataTable.DefaultView;

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("PLEASE ENTER A VALID ID");
            }


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            rights RIGHTS   = new rights();
            this.Close();
            RIGHTS.Show();
        }

        //private void delete_Click(object sender, RoutedEventArgs e)
        //{
        //    cmd = new SqlCommand("Delete from event Where cnicno = @cnicno", con);
        //    cmd.Parameters.AddWithValue("@cnicno", CNIC_of_Std.Text);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    MessageBox.Show("Record Delete Successfully");
        //    show();
        //    cleardata();

        //}
        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutData aboutData = new AboutData();
            this.Close();
            aboutData.Show();
        }
        private void Feedback_btn_Click(Object sender, RoutedEventArgs e)
        {
            Question question = new Question();
            this.Close();
            question.Show();
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            register Register = new register();
            this.Close();
            Register.Show();
        }
    }
}
