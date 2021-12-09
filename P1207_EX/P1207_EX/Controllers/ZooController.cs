using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P1207_EX.Models;
using P1207_EX.Services;
using System.Collections.Generic;

namespace P1207_EX.Controllers
{
    public class ZooController : Controller
    {
        private readonly ILogger<ZooController> _logger;
        private readonly ZooService _zooService;
        public ZooController(ILogger<ZooController> logger, ZooService zooService)
        {
            _logger = logger;
            _zooService = zooService;
        }
        // GET: ZooController1
        public ActionResult Index()
        {
            return View(_zooService.GetAll());
        }

        public IActionResult DisplayAddNewAnimal()
        {
            var empty = new ZooModel()
            {
                Name = "",
                Description = "",
                Age = 0,
                Gender = ""
            };
            return View(empty);
        }

        public IActionResult SubmitNewAnimal(ZooModel model)
        {
            _zooService.AddNewAnimal(model);
            return RedirectToAction("DisplayAddNewAnimal");
        }

        // GET: ZooController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ZooController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZooController1/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZooController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ZooController1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZooController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZooController1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
