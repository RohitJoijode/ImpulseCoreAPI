using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.Bridge;
using System.Data;
using System.Configuration;
using System.Web;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

namespace ImpulseCoreAPI.Controllers
{
    public class CommonController : Controller
    {
        private readonly DbEngine _DbEngine;

        public class RemoteIPDto
        {
            [JsonPropertyName("ipAddress")]
            public string IP { get; set; }
            [JsonPropertyName("continentCode")]
            public string ContinentCode { get; set; }
            [JsonPropertyName("continentName")]
            public string ContinentName { get; set; }
            [JsonPropertyName("countryCode")]
            public string CountryCode { get; set; }
            [JsonPropertyName("countryName")]
            public string CountryName { get; set; }
            [JsonPropertyName("city")]
            public string City { get; set; }
            //
            //[JsonPropertyName("ip")]
            //public string IP { get; set; }
            [JsonPropertyName("geo-ip")]
            public string GeoIp { get; set; }
            [JsonPropertyName("API Help")]
            public string ApiHelp { get; set; }
        }

        public static string ConString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            string constring = config.GetConnectionString("BloggingDatabase");
            return constring;
        }
        
        public static string GetRemoteIP()
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync("https://api.db-ip.com/v2/free/self").Result;
            var ip = JsonSerializer.Deserialize<RemoteIPDto>(result.ToString()).IP;
            return ip;
        }

        public static string GetIP()
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync("https://jsonip.com/").Result;
            var ip = JsonSerializer.Deserialize<RemoteIPDto>(result.ToString()).IP;
            return ip;
        }

        public void ImpulseCoreAPITransactionLog(ImpulseCoreLogModal ImpulseCoreLogModalObj)
        {
             using (SqlConnection conn = new SqlConnection(ConString()))
            {
                conn.ConnectionString = ConString();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = "SaveImpulseCoreApiTransactionLog";
                    comm.CommandType = CommandType.Text;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@APIControllerName",String.IsNullOrEmpty(ImpulseCoreLogModalObj.APIControllerName) ? (object)DBNull.Value : ImpulseCoreLogModalObj.APIControllerName);
                    comm.Parameters.AddWithValue("@ActionMethodName",String.IsNullOrEmpty(ImpulseCoreLogModalObj.ActionMethodName) ? (object)DBNull.Value : ImpulseCoreLogModalObj.ActionMethodName);
                    comm.Parameters.AddWithValue("@IP",String.IsNullOrEmpty(GetIP()) ? (object)DBNull.Value : GetIP());
                    comm.Parameters.AddWithValue("@RequestParamterData",String.IsNullOrEmpty(ImpulseCoreLogModalObj.RequestParamterData) ? (object)DBNull.Value : ImpulseCoreLogModalObj.RequestParamterData);
                    comm.Parameters.AddWithValue("@VendorName", String.IsNullOrEmpty(ImpulseCoreLogModalObj.VendorName) ? (object)DBNull.Value : ImpulseCoreLogModalObj.VendorName);
                    comm.Parameters.AddWithValue("@VendorApiKey", String.IsNullOrEmpty(ImpulseCoreLogModalObj.VendorApiKey) ? (object)DBNull.Value : ImpulseCoreLogModalObj.VendorApiKey);
                    comm.Parameters.AddWithValue("@IsError",ImpulseCoreLogModalObj.IsError == null ? (object)DBNull.Value : ImpulseCoreLogModalObj.IsError);
                    comm.Parameters.AddWithValue("@ErrorMessage", String.IsNullOrEmpty(ImpulseCoreLogModalObj.ErrorMessage) ? (object)DBNull.Value : ImpulseCoreLogModalObj.ErrorMessage);
                    comm.Parameters.AddWithValue("@Data", String.IsNullOrEmpty(ImpulseCoreLogModalObj.Data) ? (object)DBNull.Value : ImpulseCoreLogModalObj.Data);
                    comm.Parameters.AddWithValue("@EncryptRequestParamterData", String.IsNullOrEmpty(ImpulseCoreLogModalObj.EncryptRequestParamterData) ? (object)DBNull.Value : ImpulseCoreLogModalObj.EncryptRequestParamterData);
                    comm.Parameters.AddWithValue("@CreatedDate",DateTime.Now);
                    comm.Parameters.AddWithValue("@CreatedBy", String.IsNullOrEmpty(ImpulseCoreLogModalObj.CreatedBy) ? (object)DBNull.Value : ImpulseCoreLogModalObj.CreatedBy);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        comm.Parameters.Clear();
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }



    }
}
