using System.IO;
using System.Threading.Tasks;

namespace CatalogEditor.Fetcher
{
    public interface IImageFetcher
    {
        Task<FileStream> GetFileAsync(int productId);
        
        string ContentType { get; }
    }
}