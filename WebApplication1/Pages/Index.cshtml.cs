using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UploadUI.Model;
using UploadUI.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlobStorageService _blobStorageService;

        [BindProperty]
        public IFormFile File { get; set; }

        [BindProperty]
        [Required]
        public ExternalFactors Factors { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlobStorageService blobStorageService)
        {
            _logger = logger;
            _blobStorageService = blobStorageService;
        }

        public void OnGet()
        {
            _logger.LogInformation("Hello from OnGet!");
        }

        public IActionResult OnPost()
        {
            byte[] fileBytes;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream fileStream = File.OpenReadStream())
                    {
                        fileStream.CopyTo(memoryStream);
                    }

                   fileBytes = memoryStream.ToArray();

                }

                _blobStorageService.UploadFileToBlobAsync(GenerateUniqueFileName("csv"), fileBytes).Wait();
                _blobStorageService.UploadFileToBlobAsync(GenerateUniqueFileName("externalFactors"), new ExternalFactorCSV().GetCsv(Factors)).Wait();

                return RedirectToPage("/Privacy");
            }
        }

        static string GenerateUniqueFileName(string prefix)
        {
            DateTime currentDate = DateTime.Now;
            Guid guid = Guid.NewGuid();
            string fileName = $"{prefix}_{currentDate:yyyyMMdd_HHmmss}_{guid}.csv";
            return fileName;
        }
    }
}