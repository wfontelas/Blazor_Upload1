using BlazorInputFile;
using System.Threading.Tasks;

namespace Blazor_Upload1.Services
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry arquivo);
    }
}
