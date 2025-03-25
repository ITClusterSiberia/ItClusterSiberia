using Domain.Entities;

namespace Domain.Contracts.Repositories;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(Guid userId);
    
    public Task<User?> GetByAccountData(AccountData accountData);
    
    public Task<IEnumerable<User>> GetAllAsync();
    
    public Task<bool> AddAsync(User entity);
    
    //TODO: добавить метод обновления
    
    public Task<bool> DeleteAsync(Guid id);
}