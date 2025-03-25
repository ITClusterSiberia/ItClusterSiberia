using Dapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Npgsql;

namespace Persistence;

public class SystemRoleRepository : ISystemRoleRepository
{
    private readonly string _connectionString;

    public SystemRoleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<SystemRole>> GetAllAsync()
    {
        const string query = "SELECT SystemRole.name AS name, SystemRole.id AS id FROM SystemRoles AS SystemRole";
        await using var connection = new NpgsqlConnection(_connectionString);
        var result = (await connection.QueryAsync(query)).Select(systemRole => new SystemRole(systemRole.name, systemRole.id));
        return result;
    }
}