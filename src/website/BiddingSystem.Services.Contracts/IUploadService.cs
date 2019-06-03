using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BiddingSystem.Services.Contracts
{
    public interface IUploadService
    {
         Task<(string uploadLocation, bool success)> ProcessUpload(string folder, IFormFile uploadData);
    }
}