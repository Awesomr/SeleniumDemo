using System;
using System.Data.SqlClient;

namespace SeleniumWebDriver
{
    public class Logs
    {
        public static void Log(string testName, string testResult)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            var logDt = DateTime.Now.ToString("s");
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = $"insert into SelDemoLogs(LogDateTime, TestName, TestResult)values('{logDt}','{testName}','{testResult}')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

