using Microsoft.Data.SqlClient;
using System.Data;
using PortalHub.Models;
using System.Runtime.InteropServices;


namespace PortalHub.DAL

{
    public class Portal_DAL
    {
     private readonly string _connectionString;

        public Portal_DAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<PortalhubModel> GetPortalhubModels() { 
            List<PortalhubModel> portalList = new List<PortalhubModel> (); 
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Id, AppName, AppUrl, IconClass, IsActive FROM PortalhubModel WHERE IsActive = 1";

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read()) {
                    portalList.Add(new PortalhubModel {
                        Id = Convert.ToInt32(dr["ID"]),
                        AppName = dr["AppName"].ToString(),
                        AppUrl = dr["AppUrl"].ToString(),
                        IconClass  = dr["IconClass"].ToString()
                    });
                }
            }
            return portalList;
        }

    }


}
