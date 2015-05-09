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
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace PiccoloGroup
{
    /// <summary>
    /// Interaction logic for ExcelWindow.xaml
    /// </summary>
    public partial class ExcelWindow : Window
    {
        public ExcelWindow()
        {
            InitializeComponent();
        }

        private void UploadToDatabaseButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server = ealdb1.eal.local; Database = EJL84_DB; User Id=ejl84_usr; Password = Baz1nga84;");
            connection.Open();
            String FileName = @"C:\EAL\Projects\7. Final Project\Mads\CrystalViewer-11.xls";
            OleDbConnection OleDbconnection = new OleDbConnection();
            OleDbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ FileName +";Extended Properties='Excel 8.0;HDR=Yes'";

            OleDbCommand olecmd = new OleDbCommand
            ("SELECT start, slut, sal, film, længde, censur, udlejer  FROM [Sheet1$]", OleDbconnection);

            OleDbconnection.Open();
            OleDbDataReader dr = olecmd.ExecuteReader();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(connection);
            bulkcopy.DestinationTableName = "db_owner.ExcelTable1";
            while (dr.Read()) 
                { 
                    bulkcopy.WriteToServer(dr); 
                } 
                dr.Close(); 
                OleDbconnection.Close();
        
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            //OLEDB
            //string path;
            //OpenFileDialog openfile = new OpenFileDialog();
            //openfile.DefaultExt = ".xlsx|.xls";
            //openfile.Filter = "(.xlsx, .xls)|*.xlsx; *.xls";
            //openfile.Multiselect = false;
            
            //FileSelectedNameLabel.Content = openfile.FileName;


            //if (openfile.ShowDialog() == DialogResult.OK
            //{
            //    path = openfile.FileName;
            //}

            //INTEROP
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx|.xls";
            openfile.Filter = "(.xlsx, .xls)|*.xlsx; *.xls";
            openfile.Multiselect = false;
            var browsefile = openfile.ShowDialog();

            FileSelectedNameLabel.Content = openfile.FileName;

            if (browsefile == true)
            {
                UploadToDatabaseButton.IsEnabled = true;
            }
        }
    }
}
