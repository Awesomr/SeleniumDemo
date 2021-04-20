using System;
using System.Data.SqlClient;

namespace SeleniumWebDriver.DataDrivenTests
{
    public class WriteToLog
    {
        public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Search"].ConnectionString;

        public static string Log(string browser, string searchTerm, string result, decimal price = 0, string ad = "", string exception = "")
        {
            var now = DateTime.Now.ToString("s");

            ad = ad.Replace("'","");

            var sql =
                "INSERT INTO [CraigslistSelenium].[dbo].[CraigslistLogs]" +
                "(DateTimeTested, Browser, SearchTerm, Result, Price, Ad, Exception)" +
                $"VALUES ('{now}', '{browser}', '{searchTerm}', '{result}', {price}, '{ad}', '{exception}');";

            Console.WriteLine(sql);

            using (SqlConnection cnn = new SqlConnection(connStr))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0) return "Logged";
                        else return "Error in SqlCommand";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return ex.ToString();
                }
            }
        }
    }
}

