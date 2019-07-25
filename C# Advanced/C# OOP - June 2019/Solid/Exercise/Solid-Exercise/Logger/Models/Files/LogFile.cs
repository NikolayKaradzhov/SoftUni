using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Models.Contracts;
using Logger.Models.Contracts.Enumerations;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.Path = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExists();
            this.Path = Path + currentDirectory + currentFile;
        }

        public string Path { get; }

        public ulong Size => GetFileSize();

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => (int) c);

            return size;
        }

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = String.Format(format, 
                dateTime.ToString(dateFormat, CultureInfo.InvariantCulture), 
                level.ToString(), 
                message);

            return formattedMessage;
        }
    }
}