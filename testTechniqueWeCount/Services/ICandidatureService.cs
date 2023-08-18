using testTechniqueWeCount.Models;

namespace testTechniqueWeCount.Services
{
    public interface ICandidatureService
    {
        public Task<bool> save(Candidature candidature, IFormFile cv);
    }
}
