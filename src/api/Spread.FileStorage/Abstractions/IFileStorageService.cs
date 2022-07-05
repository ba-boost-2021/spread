using Spread.Common.Enums;

namespace Spread.FileStorage.Abstractions
{
    public interface IFileStorageService
    {
        Task<bool> Upload(string fileName, Stream stream, StorageType storageType, CancellationToken cancellationToken);
        string GetFileUrl(string path, StorageType storageType);
    }
}