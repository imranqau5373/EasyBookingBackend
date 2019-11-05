using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.UploadService.Interface
{
    internal interface IUploadConfiguration
    {
        string StorageConnectionString { get; }
    }
}
