DatabaseCreator creator = new();
creator.CreateDatabase(DatabaseType.PostgreSQL);
creator.CreateDatabase(DatabaseType.Oracle);


class Database
{
    public Database() { }
    public Database(DatabaseType _type, IConnection _connection, ICommand _command)
    {
        Type = _type;
        Connection = _connection;
        Command = _command;
    }
    public DatabaseType Type { get; set; }
    public IConnection Connection { get; set; }
    public ICommand Command { get; set; }
}
enum DatabaseType
{
    MsSQL,
    MySQL,
    PostgreSQL,
    Oracle
}

#region Alt Class'lar 

enum ConnectionState
{
    Open, Close
}

#region Creator

class DatabaseCreator
{
    DatabaseType _databaseType;
    IConnection _connection;
    ICommand _command;
    public Database CreateDatabase(DatabaseType databaseType)
    {
        IDatabaseFactory databaseFactory = databaseType switch
        {
            DatabaseType.MsSQL => new MsSQL(),
            DatabaseType.MySQL => new MySQL(),
            DatabaseType.PostgreSQL => new PostgreSQL(),
            DatabaseType.Oracle => new Oracle(),
        };
        _connection = databaseFactory.CreateConnection();
        _command = databaseFactory.CreateCommand();
        return new Database(_databaseType, _connection, _command);
    }
}
#endregion

#region Concrete Factory
class MsSQL : IDatabaseFactory
{
    public MsSQL()
    {
        Console.WriteLine($"{nameof(MsSQL)} veritabanı üretildi.");
    }
    public IConnection CreateConnection()
    {
        Connection connection = new Connection("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
        connection.Connect();
        return connection;
    }
    public ICommand CreateCommand()
    {
        Command command = new Command();
        command.Execute("Select * from Table1");
        return command;
    }
}

class Oracle : IDatabaseFactory
{
    public Oracle()
    {
        Console.WriteLine($"{nameof(Oracle)} veritabanı üretildi.");
    }
    public IConnection CreateConnection()
    {
        Connection connection = new Connection("Data Source=MyOracleDB;User Id=myUsername;Password=myPassword;Integrated Security=no;");
        connection.Connect();
        if (connection.ConnectionState == ConnectionState.Close)
            connection.DisConnect();
        return connection;
    }
    public ICommand CreateCommand()
    {
        Command command = new Command();
        command.Execute("Select * from Table2");
        return command;
    }
}

class MySQL : IDatabaseFactory
{
    public MySQL()
    {
        Console.WriteLine($"{nameof(MySQL)} veritabanı üretildi.");
    }
    public IConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
        connection.Connect();
        return connection;
    }
    public ICommand CreateCommand()
    {
        Command command = new Command();
        command.Execute("Select * from Table3");
        return command;
    }
}

class PostgreSQL : IDatabaseFactory
{
    public PostgreSQL()
    {
        Console.WriteLine($"{nameof(PostgreSQL)} veritabanı üretildi.");
    }
    public IConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "Provider=PostgreSQL OLE DB Provider;Data Source=myServerAddress;location=myDataBase;User ID=myUsername;password=myPassword;timeout=1000;";
        connection.Connect();
        return connection;
    }
    public ICommand CreateCommand()
    {
        Command command = new Command();
        command.Execute("Select * from Table4");
        return command;
    }
}
#endregion

#region AbstractFactory

interface IDatabaseFactory
{
    IConnection CreateConnection();
    ICommand CreateCommand();
}
#endregion

#region Abstract Products
interface IConnection
{
    ConnectionState ConnectionState { get; set; }
    string ConnectionString { get; set; }
    bool Connect();
    bool DisConnect();
}
interface ICommand
{
    void Execute(string query);
}
#endregion
#region Products
class Connection : IConnection
{
    string _connectionString;
    public Connection() { }
    public Connection(string connectionString)
    {
        _connectionString = connectionString;
    }
    public string ConnectionString { get => _connectionString; set => _connectionString = value; }
    public ConnectionState ConnectionState { get; set; }
    public bool Connect()
    {
        //baglanti islemleri
        ConnectionState = ConnectionState.Open;
        Console.WriteLine($"{ConnectionString} connection string'e Bağlantı gerçekleştirildi.");
        return true;
    }
    public bool DisConnect()
    {
        ConnectionState = ConnectionState.Close;
        Console.WriteLine("Bağlantı koparıldı.");
        return true;
    }

}
class Command : ICommand
{
    public void Execute(string query) { }
}
#endregion

#endregion
