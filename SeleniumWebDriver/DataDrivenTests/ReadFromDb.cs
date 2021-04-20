using System;
using System.Data.SqlClient;

namespace SeleniumWebDriver.DataDrivenTests
{
    public class ReadFromDb
    {
        public string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Search"].ConnectionString;

        public int GetNumberOfSearches()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.CraigslistSearches;", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
                return 0;
            }
        }

        public SearchData GetSearchData(int Id)
        {
            var query =
                $"SELECT [Id],[SearchTerm],[HasImage],[PostedToday],[IncludeNearbyAreas],[MinPrice],[MaxPrice] " +
                $"FROM [CraigslistSelenium].[dbo].[CraigslistSearches] " +
                $"WHERE Id ={Id};";

            SearchData value = new SearchData();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        value.Id = reader.GetInt32(0);
                        value.SearchTerm = reader.GetString(1);
                        value.HasImage = reader.GetBoolean(2);
                        value.PostedToday = reader.GetBoolean(3);
                        value.IncludeNearby = reader.GetBoolean(4);
                        value.MinPrice = reader.GetDecimal(5);
                        value.MaxPrice = reader.GetDecimal(6);
                    }
                }
            }
            return value;
        }
    }
}
