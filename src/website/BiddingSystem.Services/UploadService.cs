using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class UploadService : IUploadService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<UploadService> logger;
        public UploadService(IHostingEnvironment hostingEnvironment, ILogger<UploadService> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public async Task<(string uploadLocation, bool success)> ProcessUpload(string folder, IFormFile file)
        {
            try
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", folder, Guid.NewGuid().ToString());
                Directory.CreateDirectory(uploads);

                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return (filePath, true);
                }
                return (string.Empty, false);
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "File failed to upload");
                return (string.Empty, false);
            }

        }
    }
}