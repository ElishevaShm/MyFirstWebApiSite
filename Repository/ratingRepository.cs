using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class ratingRepository: IratingRepository
    {

        private readonly WebElectricStore1Context _webElectricStore1Context;
        private readonly IConfiguration _configuration;

        public ratingRepository(WebElectricStore1Context webElectricStore1Context , IConfiguration configuration)
        {
            _webElectricStore1Context = webElectricStore1Context;
            _configuration = configuration;
        }

       
        public async Task addRating(Rating rating)
        {
            DateTime RecordDate;
            string Host, Method, Path , Referer, UserAgent;

            Host = rating.Host;
            Method = rating.Method;
            Path = rating.Path;
            RecordDate = (DateTime)rating.RecordDate;
            Referer = rating.Referer;
            UserAgent = rating.UserAgent;

                string query = "INSERT INTO RATING(HOST, METHOD, PATH, Record_Date, REFERER,USER_AGENT)" +
                                "VALUES (@HOST, @METHOD, @PATH, @Record_Date, @REFERER ,@USER_AGENT)";
              

                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("WebElectricStore1")))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@HOST", SqlDbType.NChar, 50).Value = Host;
                    cmd.Parameters.Add("@METHOD", SqlDbType.NChar, 10).Value = Method;
                    cmd.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = Path;
                    cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = RecordDate;
                    cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar).Value = Referer;
                    cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, 100).Value = UserAgent;

                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();

                }

            
        }
    }
}
//await _webElectricStore1Context.Ratings.AddAsync(rating);
//            await _webElectricStore1Context.SaveChangesAsync();

//            return rating;