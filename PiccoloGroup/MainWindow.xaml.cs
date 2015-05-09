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
using System.Data;


namespace PiccoloGroup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ControllerLayer.Controller _Controller;

        public MainWindow()
        {
            InitializeComponent();
            _Controller = new ControllerLayer.Controller();

            TodaysScheduleCalendar.SelectedDate = DateTime.Today;
            MainDataGridFunction();
            ScheduleDataGrid.MinColumnWidth = 100;

            EditShowButton.IsEnabled = false;
            EditMovieButton.IsEnabled = false;
        }

        private void MainDataGridFunction()
        {
            _Controller = new ControllerLayer.Controller();

            
           
            DataTable ReceivedDT = new DataTable();
            ReceivedDT = ModifyTable(_Controller.DisplaySelectedDatesShows(Convert.ToDateTime(TodaysScheduleCalendar.SelectedDate)));
            ScheduleDataGrid.ItemsSource = ReceivedDT.AsDataView();
        }

        private int TimeToMinutes(string a, string b)
        {
            int inta = Convert.ToInt32(a);
            int intb = Convert.ToInt32(b);
            int f;

            f = (inta * 60) + intb;

            return f;
        }

        //Sorts the data-table by ExitTime, then scans it and every time the difference between two ExitTimes is equal or greater than 30 minutes,
        //it saves the positions to a list.
        //After the scan, a loop reads from the list and adds empty rows, then returns the modified data-table.
        //Used by the ModifyTable method, it converts the ExitTime to minutes, for comparison.
        private DataTable ModifyTable(DataTable GivenDataTable)
        {
            GivenDataTable.DefaultView.Sort = "ExitTime"; //Sorting by ExitTime
            GivenDataTable = GivenDataTable.DefaultView.ToTable();

            DataRowCollection DataRow = GivenDataTable.Rows;
            List<int> templist = new List<int>(); //List to save the positions for empty rows to be inserted

            for (int i = 0; i <= DataRow.Count - 1; i++) //Loop for each row
            {
                if (i != DataRow.Count - 1) //Condition to exclude scanning the last row
                {
                    string[] tempstring1 = (Convert.ToString(DataRow[i]["ExitTime"])).Split(':'); //Temporary string arrays to hold the parts of the time format
                    int exit1 = TimeToMinutes(tempstring1[0], tempstring1[1]); //And call of the TimeToMinutes method to convert it to minutes
                    string[] tempstring2 = (Convert.ToString(DataRow[i + 1]["ExitTime"])).Split(':');
                    int exit2 = TimeToMinutes(tempstring2[0], tempstring2[1]);

                    if (exit2 - exit1 >= 30) //Condition to save positions to list
                    {
                        templist.Add(i + 1);
                    }
                }
            }

            int j = 0;
            for (int i = 0; i < templist.Count; i++) //Loop that inserts empty rows, according to the positions in the list 
            {
                DataRow row = GivenDataTable.NewRow();

                GivenDataTable.Rows.InsertAt(row, templist[i] + j);
                j = j + 1;
            }

            return GivenDataTable;
        }
        private void TodaysScheduleCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            MainDataGridFunction();
        }

        private void InputExcelButton_Click(object sender, RoutedEventArgs e)
        {
            ExcelWindow ExcelW = new ExcelWindow();
            ExcelW.ShowDialog();
        }

        public void EditShowButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView TempRow = (DataRowView)ScheduleDataGrid.SelectedItem;
          
            EditShowDetailsTab.IsSelected = true;
           
            EditStartTimeTextBox.Text = Convert.ToString(TempRow["StartTime"]);
            EditEndTimeTextBox.Text = Convert.ToString(TempRow["EndTime"]);

            if (Convert.ToString(TempRow["Bio"]) == "Bio1")
            {
                Bio1RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio2")
            {
                Bio2RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio3")
            {
                Bio3RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio4")
            {
                Bio4RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio5")
            {
                Bio5RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio6")
            {
                Bio6RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio7")
            {
                Bio7RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio8")
            {
                Bio8RB.IsChecked = true;
            }
            if (Convert.ToString(TempRow["Bio"]) == "Bio9")
            {
                Bio9RB.IsChecked = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ScheduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditShowButton.IsEnabled = true;
            EditMovieButton.IsEnabled = true;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditShowButton.IsEnabled = false;
            EditMovieButton.IsEnabled = false;
        }

        private void EditMovieButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView TempRow = (DataRowView)ScheduleDataGrid.SelectedItem;

            EditMovieDetailsTab.IsSelected = true;

            //EditTitleTextBox.Text = Convert.ToString(TempRow["Title"]);
            //EditCensorTextBox.Text = Convert.ToString(TempRow["Censor"]);
            //EditLengthTextBox.Text = Convert.ToString(TempRow["Length"]);
            //EditCreditsTextBox.Text = Convert.ToString(TempRow["Credits"]);
            //EditPublisherTextBox.Text = Convert.ToString(TempRow["Publisher"]);

            //if (Convert.ToString(TempRow["Task"]) == "Easy")
            //{
            //    EasyRB.IsChecked = true;
            //}
            //if (Convert.ToString(TempRow["Task"]) == "Average")
            //{
            //    AverageRB.IsChecked = true;
            //}
            //if (Convert.ToString(TempRow["Task"]) == "Easy")
            //{
            //    HardRB.IsChecked = true;
            //}
        }

        private void GoBackButton1_Click(object sender, RoutedEventArgs e)
        {
            MainTab.IsSelected = true;
        }

        private void GoBackButton2_Click(object sender, RoutedEventArgs e)
        {
            MainTab.IsSelected = true;
        }

        private void SumbitShowEditButton_Click(object sender, RoutedEventArgs e)
        {
            _Controller = new ControllerLayer.Controller();
            
            DateTime Date = Convert.ToDateTime(EditShowDatePicker.SelectedDate);
            string Bio = null;
            DateTime StartTime = Convert.ToDateTime(EditStartTimeTextBox.Text);

            DateTime ExitTime = Convert.ToDateTime(EditStartTimeTextBox.Text);//temporary 
            int Minutes = Int32.Parse(EditLengthTextBox.Text);//temporary 

            DateTime EndTime = Convert.ToDateTime(EditEndTimeTextBox.Text);
            string Poster = EditPosterTextBox.Text;

            if (Bio1RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio1RB.Content);
            }
            if (Bio2RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio2RB.Content);
            }
            if (Bio3RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio3RB.Content);
            }
            if (Bio4RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio4RB.Content);
            }
            if (Bio5RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio5RB.Content);
            }
            if (Bio6RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio6RB.Content);
            }
            if (Bio7RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio7RB.Content);
            }
            if (Bio8RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio1RB.Content);
            }
            if (Bio9RB.IsChecked == true)
            {
                Bio = Convert.ToString(Bio9RB.Content);
            }

            _Controller.EditShowDetails(Bio, Date, StartTime, ExitTime, Minutes, EndTime, Poster);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            //PrintWindow PrintW = new PrintWindow();
            //PrintW.ShowDialog();
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
      

            AddEventTab.IsSelected = true;

        }
    }
}
