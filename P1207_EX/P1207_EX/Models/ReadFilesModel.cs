using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1207_EX.Models
{
    public class ReadFilesModel
    {
        /// <summary>
        /// Checks if data file exists. If not - creates new file with given path and populate list with default list object data.
        /// </summary>
        /// <param name="path"></param>
        public void CheckFile(string path)
        {
            if(!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void WriteToFile(string filePath, List<string> contents)
        {
            List<string> newContent = File.ReadLines(filePath).ToList();
            newContent.AddRange(contents);
            File.WriteAllLines(filePath, newContent);
            
        }

        public List<TodoModel> GetAllTodos(string filePath)
        {
            List<TodoModel> result = new List<TodoModel>();
            foreach(var rawObjectData in File.ReadLines(filePath).ToList())
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
