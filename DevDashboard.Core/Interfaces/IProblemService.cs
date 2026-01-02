using DevDashboard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Core.Services
{
    public interface IProblemService
    {
        Task<List<ProblemDto>> GetAllAsync();
        Task<ProblemDto> GetByIdAsync(int id);
        Task<List<ProblemDto>> GetBySourceAsync(string source);
        Task<ProblemDto> CreateAsync(ProblemDto dto);
        Task UpdateAsync(ProblemDto dto);
        Task DeleteAsync(int id);
    }
}
