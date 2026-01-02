using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Core.Models
{
    public class SolutionDto
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string ProblemTitle { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public int? ExecutionTime { get; set; }
        public int? MemoryUsage { get; set; }
        public string Result { get; set; }
        public int? TimeSpentMinutes { get; set; }
        public string Memo { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
