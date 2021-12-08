using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P1207_EX.Models;
using P1207_EX.Services;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace P1207_EX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataService _dataService;
        private readonly string dataFile = "list.txt";

        public HomeController(ILogger<HomeController> logger, DataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public IActionResult TodoItemsList()
        {
            var todos = _dataService.GetAll();

            var todosList = new TodoItemsListModel()
            {
                Todos = todos
            };
            return View(todosList);
        }

        public IActionResult DisplaySubmitData()
        {
            var emptyModel = new TodoModel()
            {
                Name = "",
                Description = ""
            };
            return View(emptyModel);
        }
        
        public IActionResult SendSubmitData(TodoModel model)
        {
            if(!string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Description))
            {
                _dataService.Add(model);
            }
            return RedirectToAction("DisplaySubmitData");
        }

        public IActionResult DisplaySubmitDataToFile()
        {
            var emptyModel = new TodoModel()
            {
                Name = "",
                Description = ""
            };
            return View(emptyModel);
        }

        public IActionResult SendSubmitDataToFile(TodoModel model)
        {
            ReadFilesModel rf = new ReadFilesModel();
            if (!string.IsNullOrWhiteSpace(model.Name) || !string.IsNullOrWhiteSpace(model.Description))
            {
                List<string> content = new List<string>();
                content.Add(model.ToString());
                rf.WriteToFile(dataFile, content);
            }
            return RedirectToAction("DisplaySubmitDataToFile");
        }

        public IActionResult ToDoItemsListFromFile()
        {
            ReadFilesModel rf = new ReadFilesModel();
            List<TodoModel> todoModels = new List<TodoModel>();

            rf.CheckFile(dataFile);

            return View(rf.GetAllTodos(dataFile));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
