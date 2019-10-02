using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities
{
    public class Attachment : BaseEntity, IEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string AttachmentGuid { get; set; }
    }
}
