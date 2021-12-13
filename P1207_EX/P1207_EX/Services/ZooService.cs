using Microsoft.Extensions.Logging;
using P1207_EX.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace P1207_EX.Services
{
    public class ZooService
    {
        private SqlConnection _connection;
        public ZooService(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<ZooModel> GetAll()
        {
            string query = "SELECT * FROM dbo.Animals";
            return _connection.Query<ZooModel>(query).ToList();
        }

        public void AddNewAnimal(ZooModel animal)
        {
            if (animal.Age >= 0
                && !string.IsNullOrWhiteSpace(animal.Name)
                && !string.IsNullOrWhiteSpace(animal.Description)
                && (animal.Gender == "Male" || animal.Gender == "Female"))
            {
                string query = $"INSERT INTO dbo.Animals (Name, Description, Age, Gender) VALUES ('{animal.Name}','{animal.Description}','{animal.Age}','{animal.Gender}')";
                _connection.Query<ZooModel>(query);
            }
        }

        public void DeleteAnimal(ZooModel animal)
        {
            string query = $"DELETE FROM dbo.Animals WHERE Id={animal.Id}";
            _connection.Query<ZooModel>(query);
        }

        public void UpdateAnimal(ZooModel animal)
        {
            string query =
                $"UPDATE dbo.Animals SET Name='{animal.Name}', Description='{animal.Description}', Age={animal.Age}, Gender='{animal.Gender}' WHERE Id={animal.Id}";
            _connection.Query<ZooModel>(query);
        }
    }
}
