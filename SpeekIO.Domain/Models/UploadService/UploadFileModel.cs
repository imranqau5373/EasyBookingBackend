using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.UploadService
{
    public class UploadFileModel
    {
        public byte[] File { get; set; }
        public string FileNameWithExtension { get; set; }
        public string BlobContainerName { get; set; }
    }
}
