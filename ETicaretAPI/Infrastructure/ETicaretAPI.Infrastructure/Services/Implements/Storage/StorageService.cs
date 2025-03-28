using ETicaretAPI.Application.Services.Interfaces.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Implements.Storage
{
    public class StorageService : IStorageService
    {
        public string StorageName { get => _storage.GetType().Name; }
        IStorage _storage { get; }

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        => await _storage.DeleteAsync(pathOrContainerName, fileName);

        public async Task<List<string>> GetFiles(string pathOrContainerName)
        => await _storage.GetFiles(pathOrContainerName);

        public async Task<bool> HasFile(string pathOrContainerName, string fileName)
        => await _storage.HasFile(pathOrContainerName, fileName);

        public async Task<Dictionary<string, string>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        => await _storage.UploadAsync(pathOrContainerName, files);
    }
}
