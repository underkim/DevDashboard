using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Entities
{
    public class Tag
    {
        public Tag()
        {
            ProblemTags = new List<ProblemTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public virtual ICollection<ProblemTag> ProblemTags { get; set; }
    }
}
