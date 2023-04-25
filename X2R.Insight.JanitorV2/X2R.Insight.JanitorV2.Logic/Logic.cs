using MySql.Data.MySqlClient;

namespace X2R.Insight.JanitorV2.Logic
{
    public class Logic
    {
        public string databaseConnection(string connectionString)
        {
            string result = string.Empty;
            MySqlConnection connection = new(connectionString);

            try
            {
                connection.Open();
                result = "Connection established";
                return result;
            }
            catch
            {
                result = "Connection Failed";
            }
            return result;
        }


        public string ExecuteQuery(string connectionString, string query)
        {
            MySqlConnection connection = new(connectionString);
            string result = string.Empty;

            try
            {
                
                string oString = query;
                MySqlCommand oCmd = new MySqlCommand(oString, connection);
                connection.Open();
                using (MySqlDataReader oReader = oCmd.ExecuteReader())
                {
                    int count = 0;
                    while (oReader.Read())
                    {
                        Console.WriteLine("Query: " + oReader["query"] + " ConnectionString: " + oReader["connectionstring"]);
                        count++;
                    }
                    result = $"Query is succesfully executed. {count} rows effected";
                }
            }
            catch (Exception eX)
            {
                result = "Failed to execute query: \r\n" + eX;
            }
            connection.Close();
            return result;
        }















        /* public string ExecuteQuery(string query, string connectionString)
         {
             SqlConnection connection = new SqlConnection(connectionString);
             string result = string.Empty;

             SqlCommand command = new SqlCommand(query, connection);
             connection.Open();
             SqlDataReader reader = command.ExecuteReader();
             try
             {
                 int changes = 0;
                 while (reader.Read())
                 {
                     changes++;
                 }
                 connection.Close();

                 result = $"Query is succesfully executed with {changes} changes/ rows effected";
                 return result;
             }
             finally
             {
                 reader.Close();
             }
         }*/


    }
}