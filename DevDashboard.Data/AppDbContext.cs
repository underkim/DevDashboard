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
            // Problem
            modelBuilder.Entity<Problem>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Problem>()
                .Property(p => p.Source)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Problem>()
                .Property(p => p.ProblemNo)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Problem>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            // ProblemTag 복합키
            modelBuilder.Entity<ProblemTag>()
                .HasKey(pt => new { pt.ProblemId, pt.TagId });

            modelBuilder.Entity<ProblemTag>()
                .HasRequired(pt => pt.Problem)
                .WithMany(p => p.ProblemTags)
                .HasForeignKey(pt => pt.ProblemId);

            modelBuilder.Entity<ProblemTag>()
                .HasRequired(pt => pt.Tag)
                .WithMany(t => t.ProblemTags)
                .HasForeignKey(pt => pt.TagId);

            // Solution
            modelBuilder.Entity<Solution>()
                .HasRequired(s => s.Problem)
                .WithMany(p => p.Solutions)
                .HasForeignKey(s => s.ProblemId);

            // Tag
            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();

            // DailyStats
            modelBuilder.Entity<DailyStats>()
                .HasIndex(d => d.Date)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
