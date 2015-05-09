using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Movie
    {
        public string Title { get; set; }
        public string Censor { get; set; }
        public int Length { get; set; }
        public int Credits { get; set; }
        public string Publisher { get; set; }
        public string Task { get; set; }

        public Movie(string Title, string Censor, int Length, int Credits, string Publisher, string Task)
        {
            this.Title = Title;
            this.Censor = Censor;
            this.Length = Length;
            this.Credits = Credits;
            this.Publisher = Publisher;
            this.Task = Task;
        }
    }
}
