using DevDashboard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Core.Services
{
    public interface ISolutionService
    {
        Task<List<SolutionDto>> GetAllAsync();
        Task<SolutionDto> GetByIdAsync(int id);
        Task<List<SolutionDto>> GetByProblemIdAsync(int problemId);
        Task<SolutionDto> CreateAsync(SolutionDto dto);
        Task UpdateAsync(SolutionDto dto);
        Task DeleteAsync(int id);
    }
}