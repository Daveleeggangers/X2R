using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace X2R.Insight.JanitorV2.Logic
{
    public class Logic
    {
        public static string DatabaseConnection(string connectionString)
        {
            MySqlConnection connection = new(connectionString);

            string result;
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


        public static string GetQuery(string connectionString, string query)
        {
            MySqlConnection connection = new(connectionString);
            string result = string.Empty;

            try
            {
                string oString = query;
                MySqlCommand oCmd = new(oString, connection);
                connection.Open();
                using MySqlDataReader oReader = oCmd.ExecuteReader();
                int count = 0;
                while (oReader.Read())
                {
                    Console.WriteLine("Query: " + oReader["query"] + " ConnectionString: " + oReader["connectionstring"]);
                    count++;
                }
                result = $"Query is succesfully executed. {count} row(s) effected";
            }
            catch (Exception eX)
            {
                result = "Failed to execute query: \r\n" + eX;
            }
            connection.Close();
            return result;
        }

        public static string ExecuteQuery(string query, string connectionString)
        {
            SqlConnection connection = new(connectionString);

            SqlCommand command = new(query, connection);
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

                string result = $"Query is succesfully executed with {changes} change(s)/ row(s) effected";
                return result;
            }
            finally
            {
                reader.Close();
            }
        }


    }
}