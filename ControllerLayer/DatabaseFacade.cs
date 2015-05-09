using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ControllerLayer
{
    class DatabaseFacade
    {
        static SqlConnection connection = new SqlConnection("Server = ealdb1.eal.local; Database = EJL84_DB; User Id=ejl84_usr; Password = Baz1nga84;");

        //Gets the shows from the database according to the selected date
        public DataTable DisplayShows(ModelLayer.Schedule DisplaySelectedDatesShows)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("1SelectShowsSP", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SelectedDate", DisplaySelectedDatesShows.SelectedDate));

                cmd.ExecuteNonQuery();

                SqlDataAdapter SqlDataAdp = new SqlDataAdapter(cmd);
                DataTable DataTbl = new DataTable();
                SqlDataAdp.Fill(DataTbl);

                connection.Close();

                return DataTbl;

            }

            catch
            {
                return null;
            }
        }

        //Sends the updated movie details to the database
        //public void EditMovieDetails(ModelLayer.Show NewMovie, string OldTitle)
        //{
        //    try
        //    {
        //        connection.Open();

        //        SqlCommand cmd = new SqlCommand("EditMovieDetailsSP", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(new SqlParameter("@Title", NewMovie.Title));
        //        cmd.Parameters.Add(new SqlParameter("@Length", NewMovie.Length));
        //        cmd.Parameters.Add(new SqlParameter("@Credits", NewMovie.Credits));
        //        cmd.Parameters.Add(new SqlParameter("@Censor", NewMovie.Censor));
        //        cmd.Parameters.Add(new SqlParameter("@Publisher", NewMovie.Publisher));
        //        cmd.Parameters.Add(new SqlParameter("@Task", NewMovie.Task));
        //        cmd.Parameters.Add(new SqlParameter("@OldTitle", OldTitle));

        //        cmd.ExecuteNonQuery();

        //        connection.Close();
        //    }

        //    catch
        //    {
          
        //    }
        //}
        
        public void EditShowDetails(ModelLayer.Show EditShowDetails)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("EditShowDetailsSP", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Bio", EditShowDetails.Bio));
                cmd.Parameters.Add(new SqlParameter("@Date", EditShowDetails.Date));
                cmd.Parameters.Add(new SqlParameter("@StartTime", EditShowDetails.StartTime));
                cmd.Parameters.Add(new SqlParameter("@ExitTime", EditShowDetails.ExitTime));
                cmd.Parameters.Add(new SqlParameter("@Minutes", EditShowDetails.Minutes));
                cmd.Parameters.Add(new SqlParameter("@EndTime", EditShowDetails.EndTime));  
                cmd.Parameters.Add(new SqlParameter("@Poster", EditShowDetails.Poster));

                cmd.ExecuteNonQuery();

                connection.Close();
            }

            catch
            {
             
            }
        }

        //Stores the new added event to the Database
        //public void StoreEvent(ModelLayer.Show NewEvent, ModelLayer.Movie NewEvent)
        //{
        //    try
        //    {
        //        connection.Open();

        //        SqlCommand cmd = new SqlCommand("SaveEventSP", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(new SqlParameter("@Title", NewEvent.Title));
        //        cmd.Parameters.Add(new SqlParameter("@Length", NewEvent.Length));
        //        cmd.Parameters.Add(new SqlParameter("@Credits", NewEvent.Credits));
        //        cmd.Parameters.Add(new SqlParameter("@Censor", NewEvent.Censor));
        //        cmd.Parameters.Add(new SqlParameter("@Publisher", NewEvent.Publisher));
        //        cmd.Parameters.Add(new SqlParameter("@Task", NewEvent.Task));
        //        cmd.Parameters.Add(new SqlParameter("@Bio", NewEvent.Bio));
        //        cmd.Parameters.Add(new SqlParameter("@Date", NewEvent.Date));
        //        cmd.Parameters.Add(new SqlParameter("@StartTime", NewEvent.StartTime));
        //        cmd.Parameters.Add(new SqlParameter("@ExitTime", NewEvent.ExitTime));
        //        cmd.Parameters.Add(new SqlParameter("@EndTime", NewEvent.EndTime));
        //        cmd.Parameters.Add(new SqlParameter("@Poster", NewEvent.Poster));

        //        cmd.ExecuteNonQuery();

        //        connection.Close();

        //    }

        //    catch
        //    {

        //    }

        //}
    }
}
