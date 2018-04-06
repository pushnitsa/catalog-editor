using System;
using System.IO;
using System.Threading.Tasks;
using CatalogEditor.DatabaseContext;
using CatalogEditor.Models;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace CatalogEditor.Fetcher
{
    public class ImageFetcher : IImageFetcher
    {
        private readonly IContextFactory _contextFactory;
        private readonly string _uploadFilePath;
        private string _contentType;
        private string _filePath;
        private readonly string _defaultImageRelativePath;
        
        public ImageFetcher(
            IContextFactory contextFactory, 
            string uploadFilePath,
            string defaultImageRelativePath
            )
        {
            _contextFactory = contextFactory;
            _uploadFilePath = uploadFilePath;
            _defaultImageRelativePath = defaultImageRelativePath;
        }
        
        public async Task<FileStream> GetFileAsync(int productId)
        {
            Product product;
            using (var context = _contextFactory.Create())
            {
                product = await context.Products.SingleAsync(p => p.Id == productId);
            }
            
            var file = IsFileExists(product.Image) ? GetUploadedFile(product.Image) : GetDefaultFile();
            
            new FileExtensionContentTypeProvider().TryGetContentType(_filePath, out var internalContentType);

            _contentType = internalContentType ?? "application/octet-stream";

            return file;
        }

        public string ContentType 
        {
            get
            {
                if (_contentType == null)
                {
                    throw new ArgumentException("Use GetFileAsync method first");
                }
            
                return _contentType;
            }
        }

        private bool IsFileExists(string filename)
        {
            var path = GetUploadPath() + "/" + filename;
            return File.Exists(path);
        }

        private string GetUploadPath()
        {
            return Directory.GetCurrentDirectory() + "/" + _uploadFilePath;
        }

        private FileStream GetUploadedFile(string filename)
        {
            SetFilePath(GetUploadPath() + "/" + filename);
            return File.OpenRead(_filePath);
        }

        private void SetFilePath(string filePath)
        {
            _filePath = filePath;
        }

        private FileStream GetDefaultFile()
        {
            SetFilePath(Directory.GetCurrentDirectory() + "/" + _defaultImageRelativePath);
            return File.OpenRead(_filePath);
        }
    }
}