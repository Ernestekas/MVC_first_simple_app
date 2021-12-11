using Microsoft.AspNetCore.Mvc;
using P1207_EX.Models;
using P1207_EX.Services;
using System.Diagnostics;

namespace P1207_EX.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataService _dataService;
        private readonly string _jsonFile = "data.json";

        public HomeController(DataService dataService)
        {
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
            var emptyModel = new TodoModel();
            return View(emptyModel);
        }
        
        public IActionResult SendSubmitData(TodoModel model)
        {
            _dataService.Add(model);
            return RedirectToAction("DisplaySubmitData");
        }

        public IActionResult DisplaySubmitDataToFile()
        {
            var emptyModel = new TodoModel();
            return View(emptyModel);
        }

        public IActionResult SendSubmitDataToFile(TodoModel model)
        {
            _dataService.WriteToJson(_jsonFile, model);
            return RedirectToAction("DisplaySubmitDataToFile");
        }

        public IActionResult ToDoItemsListFromFile()
        {
            return View(_dataService.GetAllJson(_jsonFile));
        }

        public IActionResult DeleteListItem(TodoModel model)
        {
            _dataService.DeleteFromJson(_jsonFile, model);
            return RedirectToAction("ToDoItemsListFromFile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
