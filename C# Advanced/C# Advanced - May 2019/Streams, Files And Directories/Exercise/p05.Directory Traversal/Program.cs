using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace p05.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileArray = Directory.GetFiles(".", "*.*");
            var reportFileDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            var files = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo dirInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = dirInfo.GetFiles();

            foreach (var file in allFiles)
            {
                double size = file.Length / 1024.0;
                string fileName = file.Name;
                string extension = file.Extension;

                if (!files.ContainsKey(extension))
                {
                    files.Add(extension, new Dictionary<string, double>());
                }

                if (!files[extension].ContainsKey(fileName))
                {
                    files[extension].Add(fileName, size);
                }
            }

            var ordered = files.OrderByDescending(x => x.Value.Count)
                   .ThenBy(y => y.Key)
                   .ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in ordered)
            {
                string fileExt = kvp.Key;

                File.AppendAllText(reportFileDesktopPath, fileExt + Environment.NewLine);

                foreach (var item in kvp.Value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(reportFileDesktopPath, $"--{item.Key} - {Math.Round(item.Value, 3)}kb {Environment.NewLine}");
                }
            }
        }
    }
}