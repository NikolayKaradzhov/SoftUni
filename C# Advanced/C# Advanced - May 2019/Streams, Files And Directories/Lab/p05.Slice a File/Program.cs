using System;
using System.IO;

namespace p05.Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputFile = new FileStream(@"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Lab\Resources\05. Slice File\sliceMe.txt", FileMode.Open))
            {
                long fileSize = inputFile.Length; //length in bytes
                long partSize = (long)Math.Ceiling(fileSize / 4.0); //splited into 4 parts
                byte[] buffer = new byte[partSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($"C:\\SoftUni\\C# Advanced\\C# Advanced - May 2019\\Streams, Files And Directories\\Lab\\Resources\\05. Slice File\\Part-{i}.txt", FileMode.Create))
                    {
                        int readedBytes = inputFile.Read(buffer, 0, buffer.Length);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}