namespace Logger.Models.Files
{
    using Logger.Models.Contracts;
    using System;
    using System.IO;
    using System.Linq;
    using Logger.Models.Contracts.Enumerations;
    using Logger.Models.IOManagement;
    using System.Globalization;


    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.IOManager.CurrentFilePath;
            this.IOManager.EnsureDirectoryAndFileExists();
        }

        public string Path => this.currentPath;

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