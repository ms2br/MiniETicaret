using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services.Interfaces.Storage.Local
{
    public interface ILocalStorage : IStorage
    {

        public Task CopyFileAsync(string path, IFormFile file);
    }
}
