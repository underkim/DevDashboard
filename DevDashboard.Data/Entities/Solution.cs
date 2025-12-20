using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Entities
{
    public class Solution
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public int? ExecutionTime { get; set; }
        public int? MemoryUsage { get; set; }
        public string Result { get; set; }
        public int? TimeSpentMinutes { get; set; }
        public string Memo { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Problem Problem { get; set; }
    }
}
