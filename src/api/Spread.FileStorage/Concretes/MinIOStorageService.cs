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

        public MinIOStorageService(IOptions<Settings> options)
        {
            this.configuration = options.Value.S3;
            this.client = new AmazonS3Client(configuration.AccessKey, configuration.SecretKey, new AmazonS3Config { ServiceURL = configuration.Url, ForcePathStyle = true });
        }

        public async Task<bool> Upload(string fileName, Stream stream, StorageType storageType, CancellationToken cancellationToken)
        {
            try
            {
                using (var transferUtility = new TransferUtility(client))
                {
                    await transferUtility.UploadAsync(stream, storageType.ToString().ToLower(new CultureInfo("en-US")), fileName, cancellationToken);
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