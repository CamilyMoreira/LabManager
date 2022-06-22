//Connection
using Microsoft.Data.Sqlite;
namespace LabManager.Database;
using Dapper;

class DatabaseSetup //precisa de uma dependencia (outra classe)
{
    private readonly DatabaseConfig _databaseConfig; //readonly serve para n pode mudar o valor e o _ serve para n dar conflito (para n usar o this)
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateComputerTable();
        CreateLabTable();
    }

    private void CreateComputerTable()
    {

    using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    //Command
    connection.Execute(@"
        CREATE TABLE IF NOT EXISTS Computers(
            id int not null primary key,
            ram varchar(100) not null,
            processor varchar(100) not null
        );
    ");
    }

    private void CreateLabTable()
    {

    using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    //Command
    connection.Execute(@"
        CREATE TABLE IF NOT EXISTS Labs(
            id int not null primary key,
            number int not null,
            name varchar(100) not null,
            block char(1) not null
        );
    ");
    }
}