using System;
using System.IO.Compression;

namespace p06.Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\Resources";
            string destinationDir = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\p06.Zip And Extract\result.zip";
            string extractDir = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\p06.Zip And Extract\ExtractDir\";

            ZipFile.CreateFromDirectory(picPath, destinationDir);

            ZipFile.ExtractToDirectory(destinationDir, extractDir);
        }
    }
}