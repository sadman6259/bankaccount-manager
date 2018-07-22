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
using System.Data;


namespace demoapp
{
    /// <summary>
    /// Interaction logic for userprogramm.xaml
    /// </summary>
    public partial class userprogramm : Window
    {


        public userprogramm()
        {
            InitializeComponent();
        }
        private string value;
        public userprogramm(string p)
            : this()
        {
            // TODO: Complete member initialization
            this.value = p;
        }
    
     //   string a;
     

    /*    private void Button_Click(object sender, RoutedEventArgs e)
        {
            string accountno = accounttext.Text;


            // int start = 1000;
            // string accountno;
            string transamount = transfertext.Text;
            int a = Convert.ToInt32(transfertext.Text);
            string dipamount = amounttext.Text;
            int b = Convert.ToInt32(amounttext.Text);
            string withamount = withdrawtext.Text;
            int c = Convert.ToInt32(withdrawtext.Text);
            int name = (b + -a - c);
            //   Convert.ToInt32(text2.Text-text3.Text-text1.Text);

            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            String insertString = "insert into tbltrans(transfer,diposit,withdraw,total,accountno) values ('" + a + "','" + b + "','" + c + "','" + name + "','" + accountno + "')";

            SqlCommand insertCommand = new SqlCommand(insertString, connection);

            insertCommand.ExecuteNonQuery();
            MessageBox.Show("your transection completed");*/

            /*    string amount = amounttext.Text;
                int a = Convert.ToInt32(amounttext.Text);
                if (amount != null)
                {
                    SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                    connection.Open();
                    String insertString = "insert into tbldeposit(accountno,amount) values ('" + accountno + "','" + amount + "')";

                    SqlCommand insertCommand = new SqlCommand(insertString, connection);

                    insertCommand.ExecuteNonQuery();


                    SqlConnection con = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;initial Catalog=Bankdb;Integrated Security=true");
                con.Open();
                    SqlCommand cma=new SqlCommand ("select a.accountno,a.amount+b.amount as currentamount from [dbo].[tblmain] a join [dbo].[tbldeposit] b on a.accountno=b.accountno",con);
                */
            //  SqlCommand updateCommand = new SqlCommand(updateString, connection);

            //  updateCommand.ExecuteNonQuery();

            /*   {
                   SqlDataAdapter da = new SqlDataAdapter();
                   da.SelectCommand =cma ;
                DataTable dt=new DataTable("tblmain");
                   da.Fill(dt);
                   griddiposit.ItemsSource = dt.DefaultView;
               }
               catch (Exception ec)
               {
                   MessageBox.Show(ec.Message);
               }
               
                

                   MessageBox.Show("your deposited amount is  " +amount);

               }*/
       //     login lo = new login();
        //    string bar = lo.accountno;
        
        private void btndeposit_Click(object sender, RoutedEventArgs e)
        {
            string accountno = accounttext.Text;
    
         


            // int start = 1000;
            // string accountno;
          //  string transamount = transfertext.Text;
          //  int a = Convert.ToInt32(transfertext.Text);
          int   a = 0;
            string dipamount = amounttext.Text;
           int b = Convert.ToInt32(amounttext.Text);
            
         //  string withamount = withdrawtext.Text;
           // int c = Convert.ToInt32(withdrawtext.Text);
          int   c = 0;
            int name = (b - a - c);
            //   Convert.ToInt32(text2.Text-text3.Text-text1.Text);
                
            {
                SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                connection.Open();
                String insertString = "insert into tbltrans(transfer,deposit,withdraw,total,accountno) values ('" + a + "','" + b + "','" + c + "','" + name + "','" + accountno + "')";

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.ExecuteNonQuery();
                MessageBox.Show("your deposit amount operation completed");
            }

        }

        private void btnshow_Click(object sender, RoutedEventArgs e)
        {


            string accountno = accounttext.Text;


            // int start = 1000;
            // string accountno;
            /*  string transamount = transfertext.Text;
            int a=  Convert.ToInt32( transfertext.Text);
              string dipamount = amounttext.Text;
          int b=    Convert.ToInt32(amounttext.Text);
              string withamount = withdrawtext.Text;
           int c=   Convert.ToInt32(withdrawtext.Text);
              int name =    (b-a-c);*/
            //   Convert.ToInt32(text2.Text-text3.Text-text1.Text);

            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select deposit,total,accountno from tbltrans where accountno = '" + accounttext.Text + "'", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltrans");
                da.Fill(dt);
                griddiposit.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            string accountno = textboxid.Text;
            
             
            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select SUM(total) AS currentAmount,accountno from tbltrans  where accountno='" + textboxid.Text + "' group by accountno", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltrans");
                da.Fill(dt);
                gridsummart.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           textboxid.Text = login.passingtext;
            accounttext.Text = login.passingtext;
            accounttext1.Text = login.passingtext;
            acctext.Text = login.passingtext;
            textboxno.Text = login.passingtext;

        }
        private void userprogramm_Load(object sender, RoutedEventArgs e)
        {
            textboxid.Text = login.passingtext;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string accountno = acctext.Text;
            string destination = destext.Text;
            int total;
            using (SqlConnection dataconnection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true"))
            using (SqlCommand datacommand = new SqlCommand("select SUM(total) AS currentAmount,accountno from tbltrans  where accountno='" + acctext.Text + "' group by accountno", dataconnection))
            {
                dataconnection.Open();
                total = Convert.ToInt32(datacommand.ExecuteScalar());

            }
            // int start = 1000;
            // string accountno;
            string transamount = amotext.Text;
            //     int a = Convert.ToInt32(transfertext.Text);
         //   string dipamount = diptext.Text;
            //   int b = Convert.ToInt32(amounttext.Text);
          //  string withamount = witext.Text;
            int a = Convert.ToInt32(amotext.Text);
          //  int b = Convert.ToInt32(diptext.Text);
           // int c = Convert.ToInt32(witext.Text);
            int b = 0;
            int c = 0;
            int name = (b - a - c);
            //   Convert.ToInt32(text2.Text-text3.Text-text1.Text);
            if (a < total)
            {
                SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                connection.Open();
                String insertString = "insert into tbltrans(transfer,deposit,withdraw,total,accountno) values ('" + a + "','" + b + "','" + c + "','" + name + "','" + accountno + "')";

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.ExecuteNonQuery();


                String updateString = "insert into tbltransfer(accountno,amount,destination) values ('" + accountno + "','" + a + "','" + destination + "' )";

                SqlCommand updateCommand = new SqlCommand(updateString, connection);

                updateCommand.ExecuteNonQuery();

                String insertSt = "insert into tbltrans(total,accountno) values ('" + transamount + "','" + destination+ "')";

                SqlCommand insertCo = new SqlCommand(insertSt, connection);

                insertCo.ExecuteNonQuery();




                MessageBox.Show("your transfer amount operation completed");
            }
            else
            {
                MessageBox.Show("your current amount is not sufficient.try again");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string accountno = acctext.Text;
           

         

            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select accountno,amount,destination from tbltransfer where accountno = '" + acctext.Text + "'", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltransfer");
                da.Fill(dt);
                gridtransfer1.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnwith_Click(object sender, RoutedEventArgs e)
        {
            
            string accountno = accounttext1.Text;
            int total;
          using(  SqlConnection dataconnection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true"))
            using(  SqlCommand datacommand = new SqlCommand("select SUM(total) AS currentAmount,accountno from tbltrans  where accountno='" + accounttext1.Text + "' group by accountno",dataconnection))
            {
                dataconnection.Open();
                total = Convert.ToInt32(datacommand.ExecuteScalar());

            }

            // int start = 1000;
            // string accountno;
          //  string transamount = transfertext1.Text;
            //     int a = Convert.ToInt32(transfertext.Text);
           // string dipamount = diposittext1.Text;
            //   int b = Convert.ToInt32(amounttext.Text);
            string withamount = amounttext1.Text;
          //  int a = Convert.ToInt32(transfertext1.Text);
            int a = 0;
            int b = 0;
           // int b = Convert.ToInt32(diposittext1.Text);
            int c = Convert.ToInt32(amounttext1.Text);
            int name = (b - a - c);
        
            //   Convert.ToInt32(text2.Text-text3.Text-text1.Text);
            if (c < total)
            {

                SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                connection.Open();
                String insertString = "insert into tbltrans(transfer,deposit,withdraw,total,accountno) values ('" + a + "','" + b + "','" + c + "','" + name + "','" + accountno + "')";

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.ExecuteNonQuery();
                MessageBox.Show("your withdraw amount operation completed");
            }
            else
            {
                MessageBox.Show("your total amount is not enough.try again");
            }

        }

        private void btnview_Click(object sender, RoutedEventArgs e)
        {
            string accountno = accounttext1.Text;



            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select withdraw,total,accountno from tbltrans where accountno = '" + accounttext1.Text + "'", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltrans");
                da.Fill(dt);
                gridwithdraw1.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnsummary_Click(object sender, RoutedEventArgs e)
        {
            string accountno = textboxid.Text;


            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select username,accountno,address,password from tblmain where accountno='" + textboxid.Text + "'", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tblmain");
                da.Fill(dt);
                gridsummart.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {

            string accountno = textboxno.Text;




            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbltrans where accountno = '" + textboxno.Text + "'", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltrans");
                da.Fill(dt);
                griddeposit.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {

        }
    }
}

    

   /*     private void btnwith_Click(object sender, RoutedEventArgs e)
        {
            string accountno = accounttext1.Text;


            // int start = 1000;
            // string accountno;
            string transamount = transfertext1.Text;
       //     int a = Convert.ToInt32(transfertext.Text);
            string dipamount = diposittext1.Text;
         //   int b = Convert.ToInt32(amounttext.Text);
            string withamount = amounttext1.Text;
            int a = Convert.ToInt32(transfertext1.Text);
            int b = Convert.ToInt32(diposittext1.Text);
            int c = Convert.ToInt32(amounttext1.Text);
            int name = (b - a - c);
            //   Convert.ToInt32(text2.Text-text3.Text-text1.Text);

            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            String insertString = "insert into tbltrans(transfer,deposit,withdraw,total,accountno) values ('" + a + "','" + b + "','" + c + "','" + name + "','" + accountno + "')";

            SqlCommand insertCommand = new SqlCommand(insertString, connection);

            insertCommand.ExecuteNonQuery();
            MessageBox.Show("your withdraw amount operation completed");
        }*/

    /*    private void btnview_Click(object sender, RoutedEventArgs e)
        {
            string accountno = accounttext1.Text;



            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select withdraw,total,accountno from tbltrans where accountno = '" + accounttext1.Text + "'", connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltrans");
                da.Fill(dt);
                gridwithdraw1.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }*/

     

  /*      private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string accountno = accounttext1.Text;
            string amount = amounttext1.Text;
          //  int b = Convert.ToInt32(value);
            //int a = Convert.ToInt32(amounttext.Text);
            if (amount != null )
            {
                SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                connection.Open();

                //Console.WriteLine(connection.State);

                String insertString = "insert into tblwithdrawal(accountno,amount) values ('" + accountno + "','" + amount + "')";

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.ExecuteNonQuery();

                 MessageBox.Show("your withdrawed amount is  " +amount);


            }
            else
            {
                MessageBox.Show("your amount is not withdrawed .try again ");
            }
        }*/

      //  private void Button_Click_2(object sender, RoutedEventArgs e)
       // {
          /*  string accountno = acctext.Text;
            string amount = amotext.Text;
            string destination = acc2text.Text;
            //  int b = Convert.ToInt32(value);
            //int a = Convert.ToInt32(amounttext.Text);
            if (amount != null)
            {
                SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

                connection.Open();

                //Console.WriteLine(connection.State);

                String insertString = "insert into tbltransfer(accountno,amount,destination) values ('" + accountno + "','" + amount + "','"+destination+"')";

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.ExecuteNonQuery();

                MessageBox.Show("your transfered amount is  " + amount);

            }
            else
            {
                MessageBox.Show("your amount is not transfered .try again ");
            }*/


      /*  private void button1_Click(object sender, RoutedEventArgs e)
        {
            string accountno = textboxid.Text;
            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;initial Catalog=Bankdb;Integrated Security=true");
            connection.Open();
            SqlCommand cmd=new SqlCommand("select username,accountno,address,amount from tblmain where accountno = '" + accountno + "'",connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
             DataTable dt=new DataTable("tblmain");
                da.Fill(dt);
                gridsummart.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
*/
     /*   private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            string accountno = textboxno.Text;
            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;initial Catalog=Bankdb;Integrated Security=true");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbldeposit where accountno = '" + accountno + "'", connection);
            try
            {
                SqlDataAdapter db = new SqlDataAdapter();
                db.SelectCommand = cmd;
                DataTable dt = new DataTable("tbldeposit");
                db.Fill(dt);
                griddeposit.ItemsSource = dt.DefaultView;
            }*/
          /*  catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
}

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            string accountno = textboxno.Text;
            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;initial Catalog=Bankdb;Integrated Security=true");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tblwithdrawal where accountno = '" + accountno + "'", connection);
            try
            {
                SqlDataAdapter db = new SqlDataAdapter();
                db.SelectCommand = cmd;
                DataTable dt = new DataTable("tblwithdrawal");
                db.Fill(dt);
                gridwithdraw.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
*/
/*        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            string accountno = textboxno.Text;
            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;initial Catalog=Bankdb;Integrated Security=true");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbltransfer where accountno = '" + accountno + "'", connection);
            try
            {
                SqlDataAdapter db = new SqlDataAdapter();
                db.SelectCommand = cmd;
                DataTable dt = new DataTable("tbltransfer");
                db.Fill(dt);
                gridtransfer.ItemsSource = dt.DefaultView;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }*/
    
