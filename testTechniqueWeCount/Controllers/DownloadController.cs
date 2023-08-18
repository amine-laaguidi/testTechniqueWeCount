using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using testTechniqueWeCount.Services;

namespace testTechniqueWeCount.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DownloadController(ICvuploadService cvuploadService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> DownloadCv(string cvPath)
        {
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", cvPath);

            if (System.IO.File.Exists(filePath))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;

                var fileExtension = Path.GetExtension(cvPath);
                var contentType = GetContentType(fileExtension);

                return File(memory, contentType, cvPath);
            }

            return NotFound();
        }

        private string GetContentType(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".pdf":
                    return "application/pdf";
                case ".jpg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
