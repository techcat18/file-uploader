using Azure.Storage.Blobs;
using FileUploader.API.Interfaces;
using FileUploader.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploader.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddScoped<IStorageService, AzureBlobStorageService>();
            services.AddScoped(_ => new BlobServiceClient(config.GetConnectionString("AzureBlobStorage")));

            return services;
        }
        
        public static IServiceCollection ConfigureCors(
            this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}