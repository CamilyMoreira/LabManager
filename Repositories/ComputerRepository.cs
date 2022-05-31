using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

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
        var computers = new List<Computer>();

        //Connection
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers;";

        //Execute
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var ram = reader.GetString(1);
            var processor = reader.GetString(2);
            var computer = new Computer(id, ram, processor);
            computers.Add(computer);

            /* Console.WriteLine("{0}, {1}, {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2)); */
        }
        connection.Close();

        return computers;
    }

    public Computer Save(Computer computer)
    {
        //Connection
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        //Execute
        command.ExecuteNonQuery();
        connection.Close();

        return computer;
    }

    public Computer GetById(int id)
    {
        //Connection
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        //Execute
        var reader = command.ExecuteReader();
        reader.Read();
        var ram = reader.GetString(1);
        var processor = reader.GetString(2);
        var computer = new Computer(id, ram, processor);

        connection.Close();

        return computer;
    }

    public Computer Update(Computer computer)
    {
        //Connection
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Computers SET ram = $ram, processor = $processor WHERE id = $id";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        //Execute
        command.ExecuteNonQuery();
        connection.Close();

        return computer;
    }

    public void Delete(int id)
    {
        //Connection
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        //Command
        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Computers WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        //Execute
        command.ExecuteNonQuery();
        connection.Close();
    }
}