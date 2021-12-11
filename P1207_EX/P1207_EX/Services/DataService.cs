using P1207_EX.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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
            if (!string.IsNullOrWhiteSpace(todo.Name) && string.IsNullOrWhiteSpace(todo.Description))
            {
                Todos.Add(todo);
            } 
        }

        private void CheckFile(string path)
        {
            if(!File.Exists(path))
            {
                if(Path.GetExtension(path) == ".json")
                {
                    File.WriteAllText(path, "[]");
                }
            }
        }
        public List<TodoModel> GetAllJson(string filePath)
        {
            CheckFile(filePath);
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TodoModel>>(json);
        }
        public void WriteToJson(string filePath, TodoModel model)
        {
            CheckFile(filePath);
            if(!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Description))
            {
                List<TodoModel> content = GetAllJson(filePath);
                content.Add(model);
                string json = JsonSerializer.Serialize(content);
                File.WriteAllText(filePath, json);
            }
        }
        public void DeleteFromJson(string filePath, TodoModel model)
        {
            CheckFile(filePath);
            List<TodoModel> content = GetAllJson(filePath);
            TodoModel selected = content.FirstOrDefault(t => t.Name == model.Name && t.Description == model.Description);
            content.Remove(selected);
            string json = JsonSerializer.Serialize(content);
            File.WriteAllText(filePath, json);
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
    }
}
