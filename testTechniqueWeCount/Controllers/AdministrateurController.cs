using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testTechniqueWeCount.Models;
using testTechniqueWeCount.Services;

namespace testTechniqueWeCount.Controllers
{
    
    public class AdministrateurController : Controller
    {
        private readonly ILogger<CandidatureController> _logger;
        private readonly ICandidatureService _candidatureService;
        public AdministrateurController(ILogger<CandidatureController> logger, ICandidatureService candidatureService)
        {
            _logger = logger;
            _candidatureService= candidatureService;
        }
        public IActionResult Index()
        {
            IEnumerable<Candidature> list = _candidatureService.list();
            return View(list);
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
