using SpeekIO.Domain.Models.UploadService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Application.Interfaces.UploadService
{
    public interface IUploadService
    {
        Task<string> UploadFileAsync(UploadFileModel uploadModel);
    }
}
