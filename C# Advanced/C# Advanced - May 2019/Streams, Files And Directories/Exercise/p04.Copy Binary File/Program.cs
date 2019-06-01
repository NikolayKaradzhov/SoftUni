using System;
using System.IO;

namespace p04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\Resources\copyMe.png";
            string picPathCopy = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\p04.Copy Binary File\copyMe-copy.png";

            using (FileStream streamReader = new FileStream(picPath, FileMode.Open))
            {
                using (FileStream streamWriter = new FileStream(picPathCopy, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];

                        int size = streamReader.Read(byteArray, 0, byteArray.Length);

                        if (size == 0)
                        {
                            break;
                        }
                        streamWriter.Write(byteArray, 0, size);
                    }
                }
            }
        }
    }
}