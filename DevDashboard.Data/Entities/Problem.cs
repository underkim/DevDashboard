using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Entities
{
    public class Problem
    {

        public Problem()
        {
            Solutions = new List<Solution>();
            ProblemTags = new List<ProblemTag>();
        }

        public int Id { get; set; }
        public string Source { get; set; }
        public string ProblemNo { get; set; }
        public string Title { get; set; }
        public string Difficulty { get; set; }
        public string Url { get; set; }
        public double? AcceptanceRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Solution> Solutions { get; set; }
        public virtual ICollection<ProblemTag> ProblemTags { get; set; }
    }
}
