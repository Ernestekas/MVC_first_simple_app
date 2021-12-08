using P1207_EX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1207_EX.Services
{
    public class DataService
    { 
        private List<TodoModel> Todos = new List<TodoModel>()
        {
            new TodoModel() {Name = "Default 1", Description = "Liurli Liurli."},
            new TodoModel() {Name = "Default 2", Description = "Bumbi bumbi."}
        };

        public List<TodoModel> GetAll()
        {
            return Todos;
        }

        public void Add(TodoModel todo)
        {
            Todos.Add(todo);
        }

        public void GetAllFromFile(string path)
        {

        }
    }
}
