using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpeekIO.Common.Helpers
{
    public static class FileUploadHelper
    {
        public static bool UploadBase64File(string base64String, string path, string name, string extension = "jpg")
        {
            //Create directory if it doesn't exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string fileName = name + "." + extension;
            //set the image path
            string imgPath = Path.Combine(path, fileName);
            byte[] imageBytes = Convert.FromBase64String(base64String.Split(',')[1]);
            File.WriteAllBytes(imgPath, imageBytes);
            return true;
        }
    }
}
