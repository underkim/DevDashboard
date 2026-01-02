using DevDashboard.Core.Models;
using DevDashboard.Data.Entities;
using DevDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDashboard.Core.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly ISolutionRepository _repository;

        public SolutionService(ISolutionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SolutionDto>> GetAllAsync()
        {
            var solutions = await _repository.GetAllAsync();
            return solutions.Select(MapToDto).ToList();
        }

        public async Task<SolutionDto> GetByIdAsync(int id)
        {
            var solution = await _repository.GetByIdAsync(id);
            return solution == null ? null : MapToDto(solution);
        }

        public async Task<List<SolutionDto>> GetByProblemIdAsync(int problemId)
        {
            var solutions = await _repository.GetByProblemIdAsync(problemId);
            return solutions.Select(MapToDto).ToList();
        }

        public async Task<SolutionDto> CreateAsync(SolutionDto dto)
        {
            var entity = MapToEntity(dto);
            var created = await _repository.AddAsync(entity);
            return MapToDto(created);
        }

        public async Task UpdateAsync(SolutionDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.Code = dto.Code;
            entity.Language = dto.Language;
            entity.ExecutionTime = dto.ExecutionTime;
            entity.MemoryUsage = dto.MemoryUsage;
            entity.Result = dto.Result;
            entity.TimeSpentMinutes = dto.TimeSpentMinutes;
            entity.Memo = dto.Memo;
            entity.SubmittedAt = dto.SubmittedAt;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Entity → DTO
        private SolutionDto MapToDto(Solution entity)
        {
            return new SolutionDto
            {
                Id = entity.Id,
                ProblemId = entity.ProblemId,
                ProblemTitle = entity.Problem?.Title,
                Code = entity.Code,
                Language = entity.Language,
                ExecutionTime = entity.ExecutionTime,
                MemoryUsage = entity.MemoryUsage,
                Result = entity.Result,
                TimeSpentMinutes = entity.TimeSpentMinutes,
                Memo = entity.Memo,
                SubmittedAt = entity.SubmittedAt
            };
        }

        // DTO → Entity
        private Solution MapToEntity(SolutionDto dto)
        {
            return new Solution
            {
                Id = dto.Id,
                ProblemId = dto.ProblemId,
                Code = dto.Code,
                Language = dto.Language,
                ExecutionTime = dto.ExecutionTime,
                MemoryUsage = dto.MemoryUsage,
                Result = dto.Result,
                TimeSpentMinutes = dto.TimeSpentMinutes,
                Memo = dto.Memo,
                SubmittedAt = dto.SubmittedAt
            };
        }
    }
}
