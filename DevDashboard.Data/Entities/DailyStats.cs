using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Entities
{
    public class DailyStats
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SolvedCount { get; set; }
        public int TotalTimeMinutes { get; set; }
    }
}
