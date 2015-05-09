using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Show
    {
        //given from Excel input
       
        public string Bio { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int Minutes { get; set; }
        public DateTime EndTime {get; set;}
        public string Poster { get; set; }

        public Show(string Bio, DateTime Date, DateTime StartTime, DateTime ExitTime, int Minutes, DateTime EndTime, string Poster)
        {
            this.Bio = Bio;
            this.Date = Date;
            this.StartTime = StartTime;
            this.ExitTime = ExitTime;
            this.Minutes = Minutes;
            this.EndTime = EndTime;
            this.Poster = Poster;         
        }
    }
}
