using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: SponsorController
        public ActionResult Sponsors()
        {
            return View();
        }

    }
}
