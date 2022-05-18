using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository
{
    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        //Connection
        var connection = new SqliteConnection("Data Source=database.db");
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
}