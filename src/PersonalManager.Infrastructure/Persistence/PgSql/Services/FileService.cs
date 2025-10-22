using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using PersonaManager.Domain.Interfaces.Services;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Services
{
    public class FileService(IConfiguration configuration) : IFileService
    {
        public void DeleteManyFileAsync(List<Resource> urls)
        {
            throw new NotImplementedException();
        }

        public void DeleteOneFileAsync(Resource file)
        {
            string basePath = configuration.GetSection("uploads:Avatar").Value;
            string fullPath = Path.Combine(basePath!, file.Url);

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public async Task<Resource> UploadAsync(IFormFile file, string folder)
        {
        
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file found");
            }

            string? basePath = configuration.GetSection("File:BasePath").Value;

            if (string.IsNullOrWhiteSpace(basePath))
                throw new Exception("No destination path found in configuration");

            string directory = Path.Combine(basePath, folder);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string extension = Path.GetExtension(file.FileName);
            string filename = Guid.NewGuid().ToString("N") + extension;
            string fullPath = Path.Combine(directory, filename);

            using (FileStream stream = new(fullPath, FileMode.Create))
                await file.CopyToAsync(stream);

            return new Resource()
            {
                Name =  filename,
                Url = Path.Combine("/", folder, filename).Replace("\\", "/"),
                ContentType = file.ContentType,
                Extensions = Path.GetExtension(file.FileName),
                Size = null
            };
                
        }

        public Task<Resource> UploadMany(List<IFormFile> files, string folder)
        {
            throw new NotImplementedException();
        }
    }
}
