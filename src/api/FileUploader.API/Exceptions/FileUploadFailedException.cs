using System;

namespace FileUploader.API.Exceptions
{
    public sealed class FileUploadFailedException: Exception
    {
        public FileUploadFailedException(): base("Failed to upload a file"){}
    }
}