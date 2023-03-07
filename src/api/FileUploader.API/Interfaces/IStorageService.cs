using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileUploader.API.Interfaces
{
    public interface IStorageService
    {
        Task UploadFileAsync(
            IFormFile file,
            string email, 
            CancellationToken cancellationToken = default);
    }
}