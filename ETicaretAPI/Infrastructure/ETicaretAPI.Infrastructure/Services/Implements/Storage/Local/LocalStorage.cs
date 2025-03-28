using ETicaretAPI.Application.Services.Interfaces.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Implements.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        public string StorageName { get; }

        public IWebHostEnvironment _webHostEnvironment { get; }

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Dictionary<string, string>> UploadAsync(string path, IFormFileCollection files)
        {
            Dictionary<string, string> fileDatas = new();
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(path,file.Name,HasFile);
                string fullPath = Path.Combine(uploadPath, newFileName);
                await CopyFileAsync(fullPath, file);
                fileDatas.Add(newFileName, fullPath);
            }
            return fileDatas;
        }

        public async Task CopyFileAsync(string path, IFormFile file)
        {
            using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            ///todo add error
        }

        public async Task DeleteAsync(string path, string fileName)
        => File.Delete(Path.Combine(path, fileName));

        public async Task<List<string>> GetFiles(string path)
        {
            DirectoryInfo directoryInfo = new(path);
            return directoryInfo.GetFiles().Select(x => x.Name).ToList();
        }

        public async Task<bool> HasFile(string path, string fileName)
        => File.Exists(Path.Combine(path, fileName));

    }
}
