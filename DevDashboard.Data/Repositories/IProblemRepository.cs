using DevDashboard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Data.Repositories
{
    public interface IProblemRepository
    {
        Task<List<Problem>> GetAllAsync();
        Task<Problem> GetByIdAsync(int id);
        Task<List<Problem>> GetBySourceAsync(string source);
        Task<Problem> AddAsync(Problem problem);
        Task UpdateAsync(Problem problem);
        Task DeleteAsync(int id);
    }
}
