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

namespace ImpulseCoreAPI.Controllers
{
    public class CommonController : Controller
    {
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
        string cmdString = @"INSERT INTO tb_RA_GLID (ID,
                                          APIControllerName, 
                                          ActionMethodName, 
                                          IP, 
                                          RequestParamterData, 
                                          VendorName, 
                                          VendorApiKey, 
                                          IsError, 
                                          ErrorMessage, 
                                          Data, 
                                          EncryptRequestParamterData,
                                          CreatedDate,
                                          CreatedBy
                                         ) 
                                          VALUES 
                                                (SCOPE_IDENTITY(),@ID,@APIControllerName,@ActionMethodName,@IP,@RequestParamterData,@VendorName,@VendorApiKey,@IsError,@ErrorMessage,@Data,@EncryptRequestParamterData,@CreatedDate,@CreatedBy);
                                                 "; //SELECT SCOPE_IDENTITY();";

             using (SqlConnection conn = new SqlConnection(ConString()))
            {
                conn.ConnectionString = ConString();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@APIControllerName",ImpulseCoreLogModalObj.APIControllerName);
                    comm.Parameters.AddWithValue("@ActionMethodName",ImpulseCoreLogModalObj.ActionMethodName);
                    comm.Parameters.AddWithValue("@IP",GetRemoteIP());
                    comm.Parameters.AddWithValue("@RequestParamterData",ImpulseCoreLogModalObj.RequestParamterData);
                    comm.Parameters.AddWithValue("@VendorName",ImpulseCoreLogModalObj.VendorName);
                    comm.Parameters.AddWithValue("@VendorApiKey",ImpulseCoreLogModalObj.VendorApiKey);
                    comm.Parameters.AddWithValue("@IsError",ImpulseCoreLogModalObj.IsError);
                    comm.Parameters.AddWithValue("@ErrorMessage",ImpulseCoreLogModalObj.ErrorMessage);
                    comm.Parameters.AddWithValue("@Data",ImpulseCoreLogModalObj.Data);
                    comm.Parameters.AddWithValue("@EncryptRequestParamterData",ImpulseCoreLogModalObj.EncryptRequestParamterData);
                    comm.Parameters.AddWithValue("@CreatedDate",DateTime.ParseExact(DateTime.Now.ToString(),"",CultureInfo.InvariantCulture));//DateTime.ParseExact(columns[3],"yyyyMMdd", CultureInfo.InvariantCulture)
                    comm.Parameters.AddWithValue("@CreatedBy",ImpulseCoreLogModalObj.CreatedBy);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
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
