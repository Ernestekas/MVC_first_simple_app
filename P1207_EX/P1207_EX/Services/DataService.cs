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
            if (!string.IsNullOrWhiteSpace(todo.Name) && string.IsNullOrWhiteSpace(todo.Description))
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
            CheckFile(filePath);
            if(!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Description))
            {
                List<string> contentToAdd = new List<string>();
                List<string> newContent = File.ReadLines(filePath).ToList();
                string todoFormated = TodoToString(model);

                contentToAdd.Add(todoFormated);

                newContent.AddRange(contentToAdd);
                newContent.Sort();
                File.WriteAllLines(filePath, newContent);
            }
        }

        public void DeleteFromFile(string filePath, TodoModel model)
        {
            CheckFile(filePath);
            List<string> contentFormated = new List<string>();
            List<TodoModel> content = GetAllTodos(filePath);
            TodoModel selectedToDelete = content.FirstOrDefault(c => c.Name == model.Name && c.Description == model.Description);
            content.Remove(selectedToDelete);

            foreach (TodoModel todo in content)
            {
                contentFormated.Add(TodoToString(todo));
            }
            contentFormated.Sort();
            File.WriteAllLines(filePath, contentFormated);
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
        
        private List<string> GetRawTodos(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
