namespace testTechniqueWeCount.Services
{
    public class CvuploadService : ICvuploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CvuploadService(IWebHostEnvironment webHostEnvironment) {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadCvAsync(string fullName, IFormFile cv)
        {
            if (cv == null || cv.Length == 0)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(cv.FileName);
            string userFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", fullName);
            Directory.CreateDirectory(userFolder);

            string filePath = Path.Combine(userFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await cv.CopyToAsync(stream);
            }

            return Path.Combine(fullName, fileName);
        }
    }
 }
