using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;


namespace MasterBlazor.APIs.Files
{
    public static class FilesEndpoints
    {
        public static void MapFilesEndpoints(this IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api/Files").WithTags(nameof(UploadedFile));

            app.MapPost("/Upload", (UploadedFile uploadedFile) =>
            {

                var path = $"{Environment.CurrentDirectory}\\Uploaded\\{uploadedFile.FileName}";
                var fs = System.IO.File.Create(path);
                fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
                fs.Close();
            })
            .WithName("FileUpload");
        }
    }
    public class UploadedFile
    {
        public string? FileName { get; set; }
        public byte[]? FileContent { get; set; }
        public string Id { get; set; } = "";
    }
}
