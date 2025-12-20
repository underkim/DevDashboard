using DevDashboard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly AppDbContext _context;

        public SolutionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Solution>> GetAllAsync()
        {
            return await _context.Solutions
                .Include(s => s.Problem)
                .OrderByDescending(s => s.SubmittedAt)
                .ToListAsync();
        }

        public async Task<List<Solution>> GetByProblemIdAsync(int problemId)
        {
            return await _context.Solutions
                .Where(s => s.ProblemId == problemId)
                .OrderByDescending(s => s.SubmittedAt)
                .ToListAsync();
        }

        public async Task<Solution> GetByIdAsync(int id)
        {
            return await _context.Solutions
                .Include(s => s.Problem)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Solution> AddAsync(Solution solution)
        {
            solution.CreatedAt = DateTime.Now;
            solution.UpdatedAt = DateTime.Now;
            _context.Solutions.Add(solution);
            await _context.SaveChangesAsync();
            return solution;
        }

        public async Task UpdateAsync(Solution solution)
        {
            solution.UpdatedAt = DateTime.Now;
            _context.Entry(solution).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var solution = await _context.Solutions.FindAsync(id);
            if (solution != null)
            {
                _context.Solutions.Remove(solution);
                await _context.SaveChangesAsync();
            }
        }
    }
}
