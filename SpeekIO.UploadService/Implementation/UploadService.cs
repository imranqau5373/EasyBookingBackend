using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SpeekIO.Application.Interfaces.UploadService;
using SpeekIO.Domain.Models.UploadService;
using SpeekIO.UploadService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.UploadService.Implementation
{
    internal class UploadService : IUploadService
    {
        private readonly IUploadConfiguration _uploadConfiguration;
        public UploadService(IUploadConfiguration uploadConfiguration)
        {
            _uploadConfiguration = uploadConfiguration;
        }
        public async Task<string> UploadFileAsync(UploadFileModel uploadModel)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_uploadConfiguration.StorageConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(uploadModel.BlobContainerName);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (uploadModel.FileNameWithExtension != null && uploadModel.File != null)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(uploadModel.FileNameWithExtension);
                    await cloudBlockBlob.UploadFromByteArrayAsync(uploadModel.File, 0, uploadModel.File.Length);
                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
