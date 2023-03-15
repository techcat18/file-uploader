using Azure.Storage.Blobs;
using FileUploader.API.Interfaces;
using FileUploader.API.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;

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
        
        public static IServiceCollection ConfigureFluentValidation(
            this IServiceCollection services)
        {
            services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly));

            return services;
        }

        public static IServiceCollection ConfigureSendGridClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(_ => new SendGridClient(configuration.GetSection("SendGrid:ApiKey").Value));

            return services;
        }
    }
}