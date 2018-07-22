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
    /// Interaction logic for adminprogramm.xaml
    /// </summary>
    public partial class adminprogramm : Window
    {
        public adminprogramm()
        {
            InitializeComponent();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            string accountno = textboxid2.Text;

            SqlConnection connection = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS; Initial Catalog=Bankdb; Integrated Security=true");

            connection.Open();
            String insertString = "DELETE FROM tblmain WHERE accountno=" +textboxid2.Text;

            SqlCommand insertCommand = new SqlCommand(insertString, connection);

            insertCommand.ExecuteNonQuery();
            MessageBox.Show("your entered account no is deleted successfully");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
