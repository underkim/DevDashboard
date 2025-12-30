using DevDashboard.Data.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DevDashboardConnection")
        {
        }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProblemTag> ProblemTags { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<DailyStats> DailyStats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // 복합키만 설정
            modelBuilder.Entity<ProblemTag>()
                .HasKey(pt => new { pt.ProblemId, pt.TagId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
