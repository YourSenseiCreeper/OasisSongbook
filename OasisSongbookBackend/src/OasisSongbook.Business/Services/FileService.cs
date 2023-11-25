using OasisSongbook.Business.Services.Interfaces;
using System.Text.RegularExpressions;

namespace OasisSongbook.Business.Services
{
    public class FileService : IFileService
    {
        private static readonly Regex ForbiddenFileSymbols = new(@"(<|>|:|\""|/|\||\?|\*)");
        private static readonly Regex DotAtTheEnd = new("/.$");
        private static readonly string[] ForbiddenFolderNames = new[] {
            "CON", "PRN", "AUX", "NUL", "COM1", "COM2",
            "COM3", "COM4", "COM5", "COM6", "COM7",
            "COM8", "COM9", "LPT1", "LPT2", "LPT3",
            "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
        };

        public void CreateFolderIfNotExist(string folderPath)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var combinedPath = Path.Combine(currentDirectory, folderPath);
            if (!Directory.Exists(combinedPath))
            {
                Directory.CreateDirectory(combinedPath);
            }
        }

        public void DeleteFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void DeleteFolder(string folderPath)
        {
            throw new NotImplementedException();
        }

        public string SterilizeFileName(string filename)
        {
            var noForbiddenSigns = ForbiddenFileSymbols.Replace(filename, string.Empty);
            if (ForbiddenFolderNames.Contains(noForbiddenSigns))
                return "nie-tym-razem";

            noForbiddenSigns = DotAtTheEnd.Replace(noForbiddenSigns, string.Empty).Trim();
            return noForbiddenSigns;
        }
    }
}
