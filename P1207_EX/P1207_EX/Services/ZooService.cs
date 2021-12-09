using Microsoft.Extensions.Logging;
using P1207_EX.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P1207_EX.Services
{
    public class ZooService
    {
        private readonly ILogger<ZooService> _logger;
        private SqlConnection _connection;
        public ZooService(ILogger<ZooService> logger, SqlConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public List<ZooModel> GetAll()
        {
            List<ZooModel> result = new List<ZooModel>();

            _connection.Open();
            var command = new SqlCommand("SELECT * FROM dbo.Animals", _connection);
            var reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                ZooModel animal = new ZooModel();
                PropertyInfo[] properties = animal.GetType().GetProperties();
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    properties[i].SetValue(animal, reader.GetValue(i));
                }
                result.Add(animal);
            }
            _connection.Close();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }

        public void AddNewAnimal(ZooModel animal)
        {
            if (animal.Age >= 0 
                && !string.IsNullOrWhiteSpace(animal.Name) 
                && !string.IsNullOrWhiteSpace(animal.Description) 
                && (animal.Gender == "Male" || animal.Gender == "Female"))
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = $"INSERT INTO dbo.Animals (Name, Description, Age, Gender) "
                    + $"VALUES ('{animal.Name}','{animal.Description}',{animal.Age},'{animal.Gender}')";

                SqlCommand command = new SqlCommand(sql, _connection);

                adapter.InsertCommand = new SqlCommand(sql, _connection);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                _connection.Close();
            }
        }
    }
}
