using P1207_EX.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace P1207_EX.Services
{
    public class SponsorService
    {
        private SqlConnection _connection;
        public SponsorService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<SponsorModel> GetAll()
        {
            string query = $"SELECT * FROM dbo.Sponsors";
            return _connection.Query<SponsorModel>(query).ToList();
        }


    }
}
