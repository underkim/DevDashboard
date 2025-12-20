using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Entities
{
    public class Settings
    {
        public int Id { get; set; }
        public string BaekjoonId { get; set; }
        public string ProgrammersId { get; set; }
        public string CodetreeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
