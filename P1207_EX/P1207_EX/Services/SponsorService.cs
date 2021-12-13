using P1207_EX.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System;

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

        public void AddNew(SponsorModel sponsor)
        {
            string animalsQuery = $"Select Id FROM dbo.Animals WHERE Id = {sponsor.AnimalId}";
            List<ZooModel> selectedAnimal = _connection.Query<ZooModel>(animalsQuery).ToList();
            if(selectedAnimal.Count > 0)
            {
                string query = $"INSERT INTO dbo.Sponsors (FirstName, Surname, Amount, AnimalId) VALUES ('{sponsor.FirstName}','{sponsor.Surname}','{sponsor.Amount}','{sponsor.AnimalId}')";
                _connection.Query<SponsorModel>(query);
            }
        }

        public void Update(SponsorModel sponsor)
        {
            string query = $"UPDATE dbo.Sponsors " +
                            $"SET FirstName='{sponsor.FirstName}', Surname='{sponsor.Surname}', Amount={sponsor.Amount}, AnimalId='{sponsor.AnimalId}' " +
                            $"WHERE Id={sponsor.Id}";
            _connection.Query<SponsorModel>(query);
        }
    }
}
