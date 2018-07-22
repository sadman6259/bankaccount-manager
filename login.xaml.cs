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
using System.Data.SqlClient;


namespace demoapp
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public static string passingtext;
        public login()
        {
            InitializeComponent();
        }

     /*   private void Button_Click(object sender, RoutedEventArgs e)
        {
            adminprogramm aform = new adminprogramm();
            aform.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             adminprogramm aform = new adminprogramm();
            aform.Show();
        }
        */
       
        //  public static class myv
    //    {
     //       public static string accountno;
     //   }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string username = ustextbox.Text;
            string password = patextbox.Text;
            if (username == "dipto" && password == "12345")
            {
                this.Hide();

                adminprogramm aform = new adminprogramm();
                aform.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
            
            }
        }
     //   public string username ;
        public string accountno1;
  
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
             string username = usernameTextbox.Text;
            
             string password = passwordTextbox.Text;
        
             passingtext = accountTextbox.Text;
 
         //   Console.WriteLine(username + ", " + password);
            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;initial Catalog=Bankdb;Integrated Security=true");
            connection.Open();
            Console.WriteLine(connection.State);


            SqlCommand selectCommand = new SqlCommand("select * from  tblmain where username = '" + username + "' and password = '" + password + "' and  accountno ='"+passingtext +"'", connection);

            SqlDataReader dataFromDb = selectCommand.ExecuteReader();


            if (dataFromDb.HasRows)
            {

                this.Hide();
                Console.Write("got");
                userprogramm uform = new userprogramm();
                 uform.Show();

            }

            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            
          //  userprogramm uform = new userprogramm();
         //   uform.Show();
        }
        }
    }

