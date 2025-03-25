using Domain.Entities;

namespace Domain.Contracts.Repositories;

public interface ISystemRoleRepository
{
    public Task<IEnumerable<SystemRole>> GetAllAsync();
}