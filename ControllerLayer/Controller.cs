using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Data;


namespace ControllerLayer
{
    public class Controller
    {      
        //Gets the selected date from the MainWindow and uses it to return the date's shows through the DatabaseFacade
        public DataTable DisplaySelectedDatesShows(DateTime SelectedDate)
        {
            ModelLayer.Schedule DisplayShowsOnDataTable = new ModelLayer.Schedule(SelectedDate);
            DatabaseFacade DB = new DatabaseFacade();
            return DB.DisplayShows(DisplayShowsOnDataTable);
        }

        //public void EditMovieDetails(string Title, string Censor, int Length, int Credits, string Publisher, string Task, string OldTitle)
        //{
        //    ModelLayer.Show ChangedMovie = new ModelLayer.Show(Title, Censor, Length, Credits, Publisher, Task);
        //    DatabaseFacade DB = new DatabaseFacade();
        //    DB.EditMovieDetails(ChangedMovie, OldTitle);
        //}

        public void EditShowDetails(string Bio, DateTime Date, DateTime StartTime, DateTime ExitTime, int Minutes, DateTime EndTime, string Poster)
        {
            ModelLayer.Show EditShowD = new ModelLayer.Show(Bio, Date, StartTime, ExitTime, Minutes, EndTime, Poster);
            DatabaseFacade DB = new DatabaseFacade();
            DB.EditShowDetails(EditShowD);
        }

        //public void CreateEvent(string Bio, DateTime Date, DateTime StartTime, DateTime EndTime, string Poster, string Title, string Censor, string Publisher, string Length, string Credits, string Task, DateTime ExitTime, int Minutes)
        //{
        //    ModelLayer.Show SaveEvent = new ModelLayer.Show(Bio, Date, StartTime, EndTime, Poster);
        //    DatabaseFacade DB = new DatabaseFacade();
        //    DB.StoreEvent(SaveEvent);
        //}
    }
}
