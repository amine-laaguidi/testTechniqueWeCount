using testTechniqueWeCount.Data;
using testTechniqueWeCount.Models;

namespace testTechniqueWeCount.Services
{
    public class CandidatureService : ICandidatureService
    {
        private readonly ICvuploadService _CvuploadService;
        private readonly ApplicationDbContext _db;
        public CandidatureService(ICvuploadService cvuploadService, ApplicationDbContext db) {
            this._CvuploadService = cvuploadService;
            this._db = db;
        }
        public async Task<bool> save(Candidature candidature, IFormFile cv)
        {
            try
            {
                candidature.CvPath = await _CvuploadService.UploadCvAsync($"{candidature.Nom} {candidature.Prenom}", cv);
                _db.Candidatures.Add(candidature);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
