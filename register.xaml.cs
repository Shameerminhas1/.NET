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
using System.Windows.Shapes;

namespace Event_System
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
    

        public register()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=CODE-X\\CODEX;Initial Catalog=vpproj;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
 
        private void Button_Click(object sender, RoutedEventArgs e)
        {

                cmd = new SqlCommand("insert into event(fullname,fathername,date,mobileno,email,event,cnicno,duration,noofguest,address) values(@fullname,@fathername,@date,@mobileno,@email,@event,@cnicno,@duration,@noofguest,@address)", con);
                cmd.Parameters.AddWithValue("@fullname", FullName.Text);
                cmd.Parameters.AddWithValue("@fathername", FatherName.Text);
                cmd.Parameters.AddWithValue("@date", DOB.Text);
                cmd.Parameters.AddWithValue("@mobileno", MobNo_of_Std.Text);
                cmd.Parameters.AddWithValue("@email", Email_of_Std.Text);
                cmd.Parameters.AddWithValue("@event", EventSelected.Text);
                cmd.Parameters.AddWithValue("@cnicno", CNIC_of_Std.Text);
                cmd.Parameters.AddWithValue("@duration", DurationSelected.Text);
                cmd.Parameters.AddWithValue("@noofguest", SchName_of_Std.Text);
                cmd.Parameters.AddWithValue("@address", Address_of_Std.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record inserted successfully");
                FullName.Clear();
                FatherName.Clear();
            DOB.Clear();
            MobNo_of_Std.Clear();
            Email_of_Std.Clear();
            EventSelected.Items.Clear();
           // EventSelected.ItemsSource = new List<string>();
            CNIC_of_Std.Clear();
            DurationSelected.Items.Clear();
           // DurationSelected.ItemsSource = new List<string>();
            SchName_of_Std.Clear();
            Address_of_Std.Clear();
            //cleardata();
        }
        

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            user user= new user();
            this.Close();
            user.Show();
        }
        private void FatherName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
