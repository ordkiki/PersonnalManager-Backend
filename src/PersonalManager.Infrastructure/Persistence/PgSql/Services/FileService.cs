using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Interfaces.Services;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Services
{
    public class FileService : IFileService
    {
        public Task<Resource> DeleteManyFileAsync(List<string> urls)
        {
            throw new NotImplementedException();
        }

        public Task<Resource> DeleteOneFileAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<Resource> UploadAsync(IFormFile file, string folder)
        {
            throw new NotImplementedException();
        }

        public Task<Resource> UploadMany(List<IFormFile> files, string folder)
        {
            throw new NotImplementedException();
        }
    }
}
