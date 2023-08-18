using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Diagnostics;
using testTechniqueWeCount.Data;
using testTechniqueWeCount.Models;
using testTechniqueWeCount.Services;

namespace testTechniqueWeCount.Controllers
{
    public class CandidatureController :Controller
    {
        private readonly ILogger<CandidatureController> _logger;
        private readonly ICandidatureService _candidatureService;
        private readonly IEmailService _emailService;

        public CandidatureController(ILogger<CandidatureController> logger, ICandidatureService candidatureService, IEmailService emailService)
        {
            _logger = logger;
            _candidatureService = candidatureService;
            _emailService = emailService;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Candidature candidature,IFormFile cv)
        {
            candidature.Nom = candidature.Nom?.Trim();
            candidature.Prenom = candidature.Prenom?.Trim();
            if (ModelState.IsValid)
            {
               await _candidatureService.save(candidature,cv);
            }
            TempData["SuccessMessage"] = "Candidature ajouté avec succès";
            var toEmail = candidature.Mail;
            var subject = "Candidature soumise avec succès";
            var body = "Bonjour "+candidature.Nom+" "+candidature.Prenom+ ", vous avez postulé avec succès.";
            _emailService.SendEmailAsync(toEmail, subject, body).Wait();
            return RedirectToAction("Create");
        }
    }
}
