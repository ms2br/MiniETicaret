using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services.Interfaces.Storage
{
    public interface IStorage
    {
        Task<Dictionary<string, string>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        Task DeleteAsync(string pathOrContainerName,string fileName);
        Task<List<string>> GetFiles(string pathOrContainerName);
        Task<bool> HasFile(string pathOrContainerName, string fileName);
    }
}
