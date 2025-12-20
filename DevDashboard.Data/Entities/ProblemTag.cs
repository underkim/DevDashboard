using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Entities
{
    public class ProblemTag
    {
        public int ProblemId { get; set; }
        public int TagId { get; set; }

        public virtual Problem Problem { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
