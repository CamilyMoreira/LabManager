using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

class ComputerRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public List<Computer> GetAll()
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var computers = connection.Query<Computer>("SELECT * FROM Computers").ToList();

        return computers;
    }

    public Computer Save(Computer computer)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        connection.Execute("INSERT INTO Computers VALUES(@Id, @Ram, @Processor)", computer);

        return GetById(computer.Id);
    }

    public Computer GetById(int id)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var computer = connection.QuerySingle<Computer>("SELECT * FROM Computers WHERE id = @Id;", new{Id = id});

        return computer;
    }

    public Computer Update(Computer computer)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        connection.Execute("UPDATE Computers SET ram = @Ram, processor = @Processor WHERE id = @Id", computer);

        return GetById(computer.Id);
    }

    public void Delete(int id)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        connection.Execute("DELETE FROM Computers WHERE id = @Id", new{Id = id});
    }

    public bool ExistsById(int id)
    {
        //Connection
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var result = connection.ExecuteScalar<Boolean>("SELECT count(id) FROM Computers WHERE id = @Id", new{Id = id});

        return result;
    }

}