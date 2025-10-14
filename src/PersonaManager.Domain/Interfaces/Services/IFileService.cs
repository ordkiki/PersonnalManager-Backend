using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Services
{
    public interface IFileService
    {
        Task<Resource> UploadAsync(IFormFile file, string folder);
        Task<Resource> UploadMany(List<IFormFile> files, string folder);
        Task<Resource> DeleteOneFileAsync(string url);
        Task<Resource> DeleteManyFileAsync(List<string> urls);
    }
}