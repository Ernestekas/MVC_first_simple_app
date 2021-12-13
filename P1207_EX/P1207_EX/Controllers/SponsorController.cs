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

        public IActionResult DisplayUpdateSponsor(SponsorModel sponsor)
        {
            return View(sponsor);
        }

        public IActionResult SubmitUpdate(SponsorModel sponsor)
        {
            try
            {
                _sponsorService.Update(sponsor);
                return RedirectToAction("Sponsors");
            }
            catch
            {
                return RedirectToAction("DisplayUpdateSponsor", sponsor);
            }
        }
    }
}
