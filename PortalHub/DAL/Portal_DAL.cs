using Microsoft.Data.SqlClient; // Ensure you have this NuGet package
using System.Data;
using PortalHub.Models;

namespace PortalHub.DAL
{
    public class Portal_DAL
    {
        private readonly string _connectionString;

        public Portal_DAL(IConfiguration configuration)
        {
            // Retrieves the connection string we verified in your appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public List<PortalhubModel> GetPortalhubModels()
        {
            List<PortalhubModel> portalList = new List<PortalhubModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Define the query string clearly
                    string query = "SELECT Id, AppName, Description, AppUrl, IconClass, DisplayOrder, IsActive, CreatedDate FROM PortalApps";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                portalList.Add(new PortalhubModel
                                {
                                    // Match the SQL column names exactly
                                    Id = Convert.ToInt32(dr["Id"]),
                                    AppName = dr["AppName"]?.ToString(),
                                    Description = dr["Description"]?.ToString(),
                                    AppUrl = dr["AppUrl"]?.ToString(),
                                    IconClass = dr["IconClass"]?.ToString(),
                                    DisplayOrder = dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0,
                                    IsActive = Convert.ToBoolean(dr["IsActive"]),
                                    CreatedDate = dr["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(dr["CreatedDate"]) : null
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // This helps us find the exact issue in the 'Output' window if the connection fails
                System.Diagnostics.Debug.WriteLine("Database Error: " + ex.Message);
            }

            return portalList;
        }
    }
}