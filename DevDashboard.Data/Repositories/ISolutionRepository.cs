using DevDashboard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Repositories
{
    public interface ISolutionRepository
    {
        Task<List<Solution>>  GetAllAsync();
        Task<List<Solution>> GetByProblemIdAsync(int problemId);
        Task<Solution> GetByIdAsync(int id);
        Task<Solution> AddAsync(Solution solution);
        Task UpdateAsync(Solution solution);
        Task DeleteAsync(int id);
    }
}
