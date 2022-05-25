//Connection
using Microsoft.Data.Sqlite;
namespace LabManager.Database;

class DatabaseSetup //precisa de uma dependencia (outra classe)
{
    private readonly DatabaseConfig _databaseConfig; //readonly serve para n pode mudar o valor e o _ serve para n dar conflito (para n usar o this)
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateComputerTable();
    }

    private void CreateComputerTable()
    {

    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
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
}