using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemiaBridge.Service.Interface
{
    public interface IStepService
    {
        Task AddAsync(StepDto stepDto); 
        Task AddManyAsync(IEnumerable<StepDto> steps);
        Task<IEnumerable<StepDto>> GetAllAsync();
        Task<StepDto?> GetByIdAsync(int id);
        Task UpdateAsync(int id, StepDto stepDto);
        Task DeleteAsync(int id);
    }
}
