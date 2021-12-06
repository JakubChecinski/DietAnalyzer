using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    // based on:
    // https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/models/file-uploads/samples/3.x/SampleApp/Utilities/FileHelpers.cs
    // note: this class could be static, but I want to use constructor for dependency injection
    public class ImageHelper
    {
        private readonly ILogger<ImageHelper> _logger;
        private string[] permittedExtensions = {".png", ".jpg", ".jpeg"};
        private long sizeLimit = 1048576; // 1MB
        private int forceWidthTo = 40;
        private int forceHeightTo = 40;

        public ImageHelper(ILogger<ImageHelper> logger)
        {
            _logger = logger;
        }

        private readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".gif", new List<byte[]> { new byte[] { 0x47, 0x49, 0x46, 0x38 } } },
            { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },
            
        };

        private bool IsValidFileExtensionAndSignature(string fileName, 
            Stream data, string[] permittedExtensions)
        {
            if (string.IsNullOrEmpty(fileName) || data == null || data.Length == 0) return false;
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext)) return false;
            data.Position = 0;
            using (var reader = new BinaryReader(data))
            {
                var signatures = _fileSignature[ext];
                var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));
                return signatures.Any(signature =>
                    headerBytes.Take(signature.Length).SequenceEqual(signature));
            }
        }

        private byte[] ForceDimensionsAndPng(byte[] originalImage)
        {
            var image = Image.Load(originalImage);
            image.Mutate(x => x.Resize(forceWidthTo, forceHeightTo));
            MemoryStream myResult = new MemoryStream();
            image.SaveAsPng(myResult);
            return myResult.ToArray();  
        }

        public byte[] ValidateFile(IFormFile formFile, ModelStateDictionary modelState)
        {
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(formFile.FileName);
            if (formFile.Length == 0)
            {
                modelState.AddModelError(formFile.Name, $"{trustedFileNameForDisplay} is empty.");
                return Array.Empty<byte>();
            }
            if (formFile.Length > sizeLimit)
            {
                var megabyteSizeLimit = sizeLimit / 1048576;
                modelState.AddModelError(formFile.Name,
                    $"The file exceeds our limit of {megabyteSizeLimit:N1} MB.");
                return Array.Empty<byte>();
            }
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    formFile.CopyTo(memoryStream);
                    if (memoryStream.Length == 0)
                    {
                        modelState.AddModelError(formFile.Name, $"{trustedFileNameForDisplay} is empty.");
                    }
                    if (!IsValidFileExtensionAndSignature(formFile.FileName, memoryStream, permittedExtensions))
                    {
                        modelState.AddModelError(formFile.Name,
                            $"Could not verify your file. The file may be corrupted.");
                    }
                    else
                    {
                        return ForceDimensionsAndPng(memoryStream.ToArray());
                    }
                }
            }
            catch (Exception exc)
            {
                modelState.AddModelError(formFile.Name,
                    $"{trustedFileNameForDisplay} upload failed. Error: {exc.Message}");
                _logger.LogError("Failed to upload file: " + exc.Message +
                    "with inner exception: " + exc.InnerException);
            }
            return Array.Empty<byte>();
        }

    }
}
