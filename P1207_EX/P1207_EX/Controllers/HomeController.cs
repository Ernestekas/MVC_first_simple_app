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
            var todosList = new TodoItemsListModel()
            {
                Todos = _dataService.GetAll()
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
            _dataService.Add(model);
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
            _dataService.WriteToFile(dataFile, model);
            return RedirectToAction("DisplaySubmitDataToFile");
        }

        public IActionResult ToDoItemsListFromFile()
        {
            return View(_dataService.GetAllTodos(dataFile));
        }

        public IActionResult DeleteListItem(TodoModel model)
        {
            _dataService.DeleteFromFile(dataFile, model);
            return RedirectToAction("ToDoItemsListFromFile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
