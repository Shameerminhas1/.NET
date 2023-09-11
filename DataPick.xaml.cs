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
    /// Interaction logic for DataPick.xaml
    /// </summary>
    public partial class DataPick : Window
    {
        public DataPick()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=CODE-X\\CODEX;Initial Catalog=vpproj;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public void show()
        {
            da = new SqlDataAdapter("select * from event", con);
            dt = new DataTable();
            da.Fill(dt);
            datagrid.ItemsSource = dt.DefaultView;
            FullName.Focus();
        }
        private void Crud_loaded(object sender, RoutedEventArgs e)
        {
            show();
        }
        public void cleardata()
        {
            FullName.Clear();
            FatherName.Clear();
            DOB.Clear();
            MobNo_of_Std.Clear();
            Email_of_Std.Clear();
            EventSelected.Items.Clear();
            CNIC_of_Std.Clear();
            DurationSelected.Items.Clear();
            SchName_of_Std.Clear();
            Address_of_Std.Clear();
        }
       
        
        public void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            cleardata();
        }

        private void insertt_Click(object sender, RoutedEventArgs e)
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
            show();
            cleardata();



            //        private int pricePerGuest = 50; // Static price per guest

            //    private void cmbPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
            //    {
            //        // Get the selected package's price from the Tag property of the selected ComboBoxItem
            //        ComboBoxItem selectedPackage = (ComboBoxItem)EventSelected.SelectedItem;
            //        int packagePrice = int.Parse(selectedPackage.Tag.ToString());

            //        // Set the price per guest based on the selected package's price
            //        pricePerGuest = packagePrice / 10;
            //    }

            //    private void btnCalculate_Click(object sender, RoutedEventArgs e)
            //    {
            //        // Get the number of guests from the text box
            //        int numGuests = int.Parse(txtGuests.Text);

            //        // Calculate the total price by multiplying the number of guests by the price per guest
            //        int totalPrice = numGuests * pricePerGuest;

            //        // Display the total price in the text block
            //        txtTotal.Text = $"Total Price: {totalPrice}";
            //    }


            //int packagePrice = int.Parse(SchName_of_Std.Tag.ToString());
            //int numGuests = int.Parse(SchName_of_Std.Text);
            //int billl = numGuests * 1000 ;
            //string packagePrice = int.Parse(billl.Tag.ToString());
            //bill.Text = billl;
        }

       


    private void Back_Click(object sender, RoutedEventArgs e)
        {
            DashbordES dash = new DashbordES();
            this.Close();
            dash.Show();
           // MainWindow mainWindow = new MainWindow();
            //this.Close();
           // mainWindow.Show();
        }

        

        private void feedback_Click(object sender, RoutedEventArgs e)
        {
           Question question= new Question();
            this.Close();
            question.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            cmd = new SqlCommand( "Delete from event Where cnicno = @cnicno", con);
            cmd.Parameters.AddWithValue("@cnicno", CNIC_of_Std.Text);
            con.Open();
        cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Delete Successfully");
            show();
            cleardata();
        
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            cmd = new SqlCommand("Update event Set fullname = @fullname,fathername = @fathername,date = @date ,mobileno = @mobileno,email=@email,event=@event,cnicno=@cnicno,duration=@duration,noofguest=@noofguest,address=@address Where cnicno=@cnicno", con);
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
            MessageBox.Show("Record updated successfully");
            show();
            cleardata();

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(datagrid.SelectedItem != null)
                {
                    FullName.Text = ((DataRowView)datagrid.SelectedItem).Row["fullname"] .ToString();
                    FatherName.Text = ((DataRowView)datagrid.SelectedItem).Row["fathername"].ToString();
                    DOB.Text = ((DataRowView)datagrid.SelectedItem).Row["date"].ToString();
                    MobNo_of_Std.Text = ((DataRowView)datagrid.SelectedItem).Row["mobileno"].ToString();
                    Email_of_Std.Text = ((DataRowView)datagrid.SelectedItem).Row["email"].ToString();
                    EventSelected.Text = ((DataRowView)datagrid.SelectedItem).Row["event"].ToString();
                    CNIC_of_Std.Text = ((DataRowView)datagrid.SelectedItem).Row["cnicno"].ToString();
                    DurationSelected.Text = ((DataRowView)datagrid.SelectedItem).Row["duration"].ToString();
                    SchName_of_Std.Text = ((DataRowView)datagrid.SelectedItem).Row["noofguest"].ToString();
                    Address_of_Std.Text = ((DataRowView)datagrid.SelectedItem).Row["address"].ToString();

                    FullName.Text = ((DataRowView)datagrid.SelectedItem).Row["fullname"].ToString();
                }
                
            }
            catch(Exception) {
            
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            DashbordES dashbordES = new DashbordES();
            this.Close();
            dashbordES.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            rights RIGHTS = new rights();
            this.Close();
            RIGHTS.Show();
        }

        private void FatherName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            feedrec fr = new feedrec();
            this.Close();
            fr.Show();
          
        }
    }
}
