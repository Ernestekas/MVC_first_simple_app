using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1207_EX.Models;
using P1207_EX.Services;

namespace P1207_EX.Controllers
{
    public class SponsorController : Controller
    {
        private readonly SponsorService _sponsorService;
        public SponsorController(SponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public IActionResult Sponsors()
        {
            return View(_sponsorService.GetAll());
        }

        public IActionResult DisplayAddSponsor()
        {
            return View(new SponsorModel());
        }

        public IActionResult SubmitAddNewSponsor(SponsorModel sponsor)
        {
            _sponsorService.AddNew(sponsor);
            return RedirectToAction("Sponsors");
        }
    }
}
