using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FileUploader.API.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileUploader.API.Services
{
    public class AzureBlobStorageService: IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private const string ContainerName = "documents";

        public AzureBlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
    
        public async Task UploadFileAsync(
            IFormFile file,
            string email,
            CancellationToken cancellationToken = default)
        {
            var blobContainerClient = GetContainerClient(ContainerName);
            
            var fileName = $"{email}/{file.FileName}";
            
            var blobClient = blobContainerClient.GetBlobClient(fileName);
        
            await using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true, cancellationToken);
        }
        
        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }
    }
}