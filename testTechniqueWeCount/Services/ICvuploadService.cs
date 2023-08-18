namespace testTechniqueWeCount.Services
{
    public interface ICvuploadService
    {
        public Task<string> UploadCvAsync(string fullName, IFormFile cv);
    }
}
