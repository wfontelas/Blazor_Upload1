using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blazor_Upload1.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        public FileUpload(IWebHostEnvironment env)
        {
            _environment = env;
        }
        public async Task UploadAsync(IFileListEntry arquivoEntrada)
        {
            try
            {
                var path = Path.Combine(_environment.ContentRootPath, "Uploads",
                    arquivoEntrada.Name);

                var ms = new MemoryStream();

                await arquivoEntrada.Data.CopyToAsync(ms);

                using (FileStream arquivo = new FileStream(path, FileMode.Create,
                    FileAccess.Write))
                {
                    ms.WriteTo(arquivo);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
