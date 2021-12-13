using Microsoft.AspNetCore.Mvc;
using P1207_EX.Models;
using P1207_EX.Services;

namespace P1207_EX.Controllers
{
    public class ZooController : Controller
    {
        private readonly ZooService _zooService;
        public ZooController(ZooService zooService)
        {
            _zooService = zooService;
        }
        // GET: ZooController1
        public ActionResult Index()
        {
            return View(_zooService.GetAll());
        }

        public IActionResult DisplayAddNewAnimal()
        {
            var empty = new ZooModel();
            return View(empty);
        }

        public IActionResult SubmitNewAnimal(ZooModel model)
        {
            _zooService.AddNewAnimal(model);
            return RedirectToAction("DisplayAddNewAnimal");
        }

        public IActionResult DeleteAnimal(ZooModel model)
        {
            _zooService.DeleteAnimal(model);
            return RedirectToAction("Index");
        }

        public IActionResult DisplayUpdateAnimal(ZooModel model)
        {
            return View(model);
        }

        public IActionResult SubmitUpdate(ZooModel model)
        {
            _zooService.UpdateAnimal(model);
            return RedirectToAction("Index");
        }
    }
}
