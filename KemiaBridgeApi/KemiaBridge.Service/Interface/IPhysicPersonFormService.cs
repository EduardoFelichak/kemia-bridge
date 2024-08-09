using KemiaBridge.Domain.DTos;

namespace KemiaBridge.Service.Interface
{
    public interface IPhysicPersonFormService
    {
        Task AddAsync(PhysicPersonFormDto physicPersonFormDto);
    }
}
