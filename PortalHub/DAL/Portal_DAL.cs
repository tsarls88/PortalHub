using Microsoft.Data.SqlClient;
using System.Data;
using PortalHub.Models;
using System.Runtime.InteropServices;


namespace PortalHub.DAL

{
    public class Portal_DAL
    {
     private readonly string _connectionString = "";

        public Portal_DAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<PortalhubModel> GetPortalhubModels()
        {
            
            List<PortalhubModel> portalList = new List<PortalhubModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                  
                    string query = "SELECT Id, AppName, AppUrl, IconClass FROM PortalApps WHERE IsActive = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                portalList.Add(new PortalhubModel
                                {
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
                // Debugging: This prints to the Visual Studio Output window
                System.Diagnostics.Debug.WriteLine("Database Error: " + ex.Message);
            }

            return portalList;
        }

    }


}
