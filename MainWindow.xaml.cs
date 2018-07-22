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
using System.Data.SqlClient;


namespace demoapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string p;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
       // public string amount = amounttextbox.Text;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                string username = usertextbox.Text;
                string password = passtextbox.Text;
                string email = emailtextbox.Text;
                string confirmpassword = confirmtextbox.Text;
                string accountno = accounttextbox.Text;
              string amount = amounttextbox.Text;
                string address= addresstextbox.Text;
           //     userprogramm up = new userprogramm(amounttextbox.Text.Trim());
           //     up.Show();




                /*       if (username == "dipto" && password == "12345")
                       {
                           this.Hide();
                    
                    
                       }
                       else
                       {
                           MessageBox.Show("Login failed");
                       }*/
                if (!email.Contains("@"))
                {
                    emaillabel.Foreground = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    emaillabel.Foreground = System.Windows.Media.Brushes.Blue;
                }

                if (password != confirmpassword)
                {
                    passlabel.Foreground = System.Windows.Media.Brushes.Red;
                    confirmlabel.Foreground = System.Windows.Media.Brushes.Red; 
                }

                else
                {
                    passlabel.Foreground = System.Windows.Media.Brushes.Blue;
                    confirmlabel.Foreground = System.Windows.Media.Brushes.Blue;
                }
                if (password == confirmpassword && email.Contains("@") && username != null)
                {
                    SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                    connection.Open();

                    //Console.WriteLine(connection.State);

                    String insertString = "insert into tblmain(username,email,password,confirmpassword,accountno,amount,address) values ('" + username + "','" + email + "','" + password + "','" + confirmpassword + "','" + accountno + "','" + amount + "','" + address + "')";

                    SqlCommand insertCommand = new SqlCommand(insertString, connection);

                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show("your registration is completed .now login for access ur account ");



                }
            } 
            
           // login loginform = new login();
          //  loginform.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mform = new MainWindow();
            mform.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            login loginform = new login();
            loginform.Show();

        }

        private void amounttextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
    }
}
