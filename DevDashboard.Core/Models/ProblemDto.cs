using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Core.Models
{
    public class ProblemDto
    {
        public ProblemDto()
        {
            Tags = new List<string>();
        }

        public int Id { get; set; }
        public string Source { get; set; }
        public string ProblemNo { get; set; }
        public string Title { get; set; }
        public string Difficulty { get; set; }
        public string Url { get; set; }
        public double? AcceptanceRate { get; set; }
        public List<string> Tags { get; set; }
        public int SolutionCount { get; set; }
    }
}