using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Implements.Storage
{
    public class Storage
    {

        protected delegate Task<bool> HasFile(string pathOrContainerName, string fileName);

        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName,HasFile hasFile)
        {
            return await Task.Run(async () =>
             {
                 string extension = Path.GetExtension(fileName);
                 string name = NameOperation.CharacterRegulatory(Path.GetFileNameWithoutExtension(fileName));
                 int counter = 1;
                 if (!await hasFile(pathOrContainerName, fileName))
                     return $"{name}{extension}";
                 string newFileName = string.Empty;
                 if (!string.IsNullOrWhiteSpace(name))
                 {
                     do
                     {
                         newFileName = $"{name}-{counter}{extension}";
                         counter++;
                     } while (await hasFile(pathOrContainerName, $"{newFileName}{extension}"));
                     return newFileName;
                 }
                 return $"{Guid.NewGuid()}{extension}";
             });
        }
    }
}
