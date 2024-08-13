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
        Task<IEnumerable<Step>> GetAllAsync();
        Task<Step?> GetByIdAsync(int id);
        Task UpdateAsync(int id, StepDto stepDto);
        Task DeleteAsync(int id);
    }
}
