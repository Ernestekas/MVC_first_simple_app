using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace P1207_EX.Controllers
{
    public class SponsorController : Controller
    {
        // GET: SponsorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SponsorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SponsorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SponsorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: SponsorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SponsorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: SponsorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SponsorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
