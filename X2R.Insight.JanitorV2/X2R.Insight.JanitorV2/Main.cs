using X2R.Insight.JanitorV2.Logic;


string connectionString = $"server=127.0.0.1;port=3306;database=janitorv2;uid=root;password=";
string query = $"SELECT * FROM `db-connections` WHERE id=1";

var _ = new Logic();


Console.WriteLine(Logic.DatabaseConnection(connectionString));

Console.WriteLine(Logic.GetQuery(connectionString, query));

string getQueryString = Console.ReadLine();
string getConnectionString = Console.ReadLine();

Console.WriteLine(Logic.ExecuteQuery(getQueryString, getConnectionString));

Console.ReadLine();

//string connectionString = @"Server=localhost\SQLExpress;Database=master;Trusted_Connection=True;";