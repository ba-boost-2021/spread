using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;
using Spread.Common;
using Spread.Common.Enums;
using Spread.FileStorage.Abstractions;
using System.Globalization;

namespace Spread.FileStorage.Concretes
{
    internal class MinIOStorageService : IFileStorageService
    {
        private readonly Settings.S3Configuration configuration;
        private readonly AmazonS3Client client;
        private readonly CultureInfo culture;

        public MinIOStorageService(IOptions<Settings> options)
        {
            culture = new CultureInfo("en-US");
            this.configuration = options.Value.S3;
            this.client = new AmazonS3Client(configuration.AccessKey, configuration.SecretKey, new AmazonS3Config { ServiceURL = configuration.Url, ForcePathStyle = true });
        }

        public string GetFileUrl(string path, StorageType storageType)
        {
            return $"{configuration.ClientUrl}/{storageType.ToString().ToLower(culture)}/{path}";
        }

        public async Task<bool> Upload(string fileName, Stream stream, StorageType storageType, CancellationToken cancellationToken)
        {
            try
            {
                using (var transferUtility = new TransferUtility(client))
                {
                    await transferUtility.UploadAsync(stream, storageType.ToString().ToLower(culture), fileName, cancellationToken);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}