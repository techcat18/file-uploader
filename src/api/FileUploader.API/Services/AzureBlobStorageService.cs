using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using FileUploader.API.Exceptions;
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

            var options = GetBlobOptions(blobClient, email);

            try
            {
                await using var stream = file.OpenReadStream();
                await blobClient.UploadAsync(stream, options, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new FileUploadFailedException();
            }
        }
        
        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }

        private BlobUploadOptions GetBlobOptions(BlobBaseClient blobClient, string email)
        {
            var metadata = new Dictionary<string, string>
            {
                ["Email"] = email
            };

            var blobOptions = new BlobUploadOptions
            {
                Metadata = metadata
            };

            return blobOptions;
        }
    }
}