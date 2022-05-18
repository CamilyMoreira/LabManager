//Connection
using Microsoft.Data.Sqlite;
namespace LabManager.Database;

class DatabaseSetup
{
    public DatabaseSetup()
    {
        CreateComputerTable();
        CreateLabTable();
    }

    private void CreateComputerTable()
    {

    var connection = new SqliteConnection("Data Source=database.db");
    connection.Open();

    //Command
    var command = connection.CreateCommand();
    command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Computers(
            id int not null primary key,
            ram varchar(100) not null,
            processor varchar(100) not null
        );
    ";

    //Execute
    command.ExecuteNonQuery();
    connection.Close();
    }

    private void CreateLabTable()
    {

    }

    /* public void CreateUsersTable()
    {

    } */
}