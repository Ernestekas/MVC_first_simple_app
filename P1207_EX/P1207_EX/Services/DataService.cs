using P1207_EX.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (!string.IsNullOrWhiteSpace(todo.Name) || string.IsNullOrWhiteSpace(todo.Description))
            {
                Todos.Add(todo);
            } 
        }

        private void CheckFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void WriteToFile(string filePath, TodoModel model)
        {
            if(!string.IsNullOrWhiteSpace(model.Name) || !string.IsNullOrWhiteSpace(model.Description))
            {
                string todoFormated = $"{model.Name} - {model.Description}";
                List<string> newContent = File.ReadLines(filePath).ToList();
                
                newContent.Add(todoFormated);
                File.WriteAllLines(filePath, newContent);
            }
        }

        public List<TodoModel> GetAllTodos(string filePath)
        {
            CheckFile(filePath);
            List<TodoModel> result = new List<TodoModel>();
            
            foreach (var rawObjectData in File.ReadLines(filePath).ToList())
            {
                string name = rawObjectData.Split('-')[0].Trim();
                string description = rawObjectData.Split('-')[1].Trim();
                result.Add(new TodoModel() { Name = name, Description = description });
            }

            return result;
        }

        public string TodoToString(TodoModel todo)
        {
            return $"{todo.Name} - {todo.Description}";
        }
    }
}
