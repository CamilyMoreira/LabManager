using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public List<Lab> GetAll()
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var computers = connection.Query<Lab>("SELECT * FROM Labs").ToList();

        return computers;
    }

    public Lab Save(Lab lab)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        connection.Execute("INSERT INTO Labs VALUES(@Id, @Namber, @Name, @Block)", lab);

        return GetById(lab.Id);
    }

    public Lab GetById(int id)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var lab = connection.QuerySingle<Lab>("SELECT * FROM Labs WHERE id = @Id;", new{Id = id});

        return lab;
    }

    public Lab Update(Lab lab)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        connection.Execute("UPDATE Labs SET number = @Number, name = @Name, block = @Block WHERE id = @Id", lab);

        return GetById(lab.Id);
    }

    public void Delete(int id)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        connection.Execute("DELETE FROM Labs WHERE id = @Id", new{Id = id});
    }

    public bool ExistsById(int id)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var result = connection.ExecuteScalar<Boolean>("SELECT count(id) FROM Labs WHERE id = @Id", new{Id = id});

        return result;
    }

}