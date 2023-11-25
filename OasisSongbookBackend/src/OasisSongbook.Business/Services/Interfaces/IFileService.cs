namespace OasisSongbook.Business.Services.Interfaces
{
    public interface IFileService
    {
        void CreateFolderIfNotExist(string folderPath);
        void DeleteFile(string filePath);
        void DeleteFolder(string folderPath);
        string SterilizeFileName(string filename);
    }
}
