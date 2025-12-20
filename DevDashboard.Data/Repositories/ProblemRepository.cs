using DevDashboard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly AppDbContext _context;

        public ProblemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Problem>> GetAllAsync()
        {
            return await _context.Problems
                .Include(p => p.ProblemTags.Select(pt => pt.Tag))
                .Include(p => p.Solutions)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Problem> GetByIdAsync(int id)
        {
            return await _context.Problems
                .Include(p => p.ProblemTags.Select(pt => pt.Tag))
                .Include(p => p.Solutions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Problem>> GetBySourceAsync(string source)
        {
            return await _context.Problems
                .Where(p => p.Source == source)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Problem> AddAsync(Problem problem)
        {
            problem.CreatedAt = DateTime.Now;
            problem.UpdatedAt = DateTime.Now;
            _context.Problems.Add(problem);
            await _context.SaveChangesAsync();
            return problem;
        }

        public async Task UpdateAsync(Problem problem)
        {
            problem.UpdatedAt = DateTime.Now;
            _context.Entry(problem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var problem = await _context.Problems.FindAsync(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
