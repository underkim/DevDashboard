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
    public class ProblemService : IProblemService
    {
        private readonly IProblemRepository _repository;

        public ProblemService(IProblemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProblemDto>> GetAllAsync()
        {
            var problems = await _repository.GetAllAsync();
            return problems.Select(MapToDto).ToList();
        }

        public async Task<ProblemDto> GetByIdAsync(int id)
        {
            var problem = await _repository.GetByIdAsync(id);
            return problem == null ? null : MapToDto(problem);
        }

        public async Task<List<ProblemDto>> GetBySourceAsync(string source)
        {
            var problems = await _repository.GetBySourceAsync(source);
            return problems.Select(MapToDto).ToList();
        }

        public async Task<ProblemDto> CreateAsync(ProblemDto dto)
        {
            var entity = MapToEntity(dto);
            var created = await _repository.AddAsync(entity);
            return MapToDto(created);
        }

        public async Task UpdateAsync(ProblemDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.Source = dto.Source;
            entity.ProblemNo = dto.ProblemNo;
            entity.Title = dto.Title;
            entity.Difficulty = dto.Difficulty;
            entity.Url = dto.Url;
            entity.AcceptanceRate = dto.AcceptanceRate;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Entity → DTO
        private ProblemDto MapToDto(Problem entity)
        {
            return new ProblemDto
            {
                Id = entity.Id,
                Source = entity.Source,
                ProblemNo = entity.ProblemNo,
                Title = entity.Title,
                Difficulty = entity.Difficulty,
                Url = entity.Url,
                AcceptanceRate = entity.AcceptanceRate,
                Tags = entity.ProblemTags != null
                    ? entity.ProblemTags.Select(pt => pt.Tag.Name).ToList()
                    : new List<string>(),
                SolutionCount = entity.Solutions != null
                    ? entity.Solutions.Count
                    : 0
            };
        }

        // DTO → Entity
        private Problem MapToEntity(ProblemDto dto)
        {
            return new Problem
            {
                Id = dto.Id,
                Source = dto.Source,
                ProblemNo = dto.ProblemNo,
                Title = dto.Title,
                Difficulty = dto.Difficulty,
                Url = dto.Url,
                AcceptanceRate = dto.AcceptanceRate
            };
        }
    }
}
