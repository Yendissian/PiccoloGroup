using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Schedule
    {
        public DateTime SelectedDate { get; set; }

        public Schedule(DateTime SelectedDate)
        {
            this.SelectedDate = SelectedDate;
        }
    }
}
