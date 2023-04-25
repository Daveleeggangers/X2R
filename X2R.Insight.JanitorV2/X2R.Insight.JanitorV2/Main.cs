using X2R.Insight.JanitorV2.Logic;

string connectionString = $"server=127.0.0.1;port=3306;database=janitorv2;uid=root;password=";
string query = $"SELECT * FROM `db-connections`";

var logic = new Logic();


Console.WriteLine(logic.databaseConnection(connectionString));

Console.WriteLine(logic.ExecuteQuery(connectionString, query));




Console.ReadLine();