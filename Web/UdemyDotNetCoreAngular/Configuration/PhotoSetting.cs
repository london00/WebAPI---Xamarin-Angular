using System;
using System.Linq;

namespace UdemyDotNetCoreAngular.Configuration
{
    public class PhotoSetting
    {
        public int MaxBytes { get; set; }
        public string[] AceptedFileTypes { get; set; }

        public bool IsSupported(string extension) => AceptedFileTypes.Contains(extension);
    }
}
