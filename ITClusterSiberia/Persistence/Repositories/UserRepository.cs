using Dapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Npgsql;

namespace Persistence;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    
    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public Task<User?> GetByIdAsync(Guid userId)
    {
        const string query = "SELECT * FROM Users WHERE Id = @userId";
        using var connection = new NpgsqlConnection(_connectionString);
        var user = connection.QuerySingleOrDefaultAsync<User>(query, userId);
        return user;
    }

    public Task<User?> GetByAccountData(AccountData accountData)
    {
        const string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
        using var connection = new NpgsqlConnection(_connectionString);
        var user = connection.QuerySingleOrDefaultAsync<User>(query, accountData);
        return user;
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        const string query = "SELECT * FROM Users";
        using var connection = new NpgsqlConnection(_connectionString);
        var users = connection.QueryAsync<User>(query);
        return users;
    }

    public async Task<bool> AddAsync(User entity)
    {
        const string query =
            @"INSERT INTO 
            Users (Id, FirstName, LastName, UserName, Email, PhoneNumber, Password, SystemRoleId, BirthDate)
            VALUES (@Id, @FirstName, @LastName, @UserName, @Email, @PhoneNumber, @Password, @SystemRoleId, @BirthDate)";
        await using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteAsync(query, entity) == 1;
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}