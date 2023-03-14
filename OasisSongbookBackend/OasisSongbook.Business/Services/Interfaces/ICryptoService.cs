namespace OasisSongbook.Business.Services.Interfaces
{
    public interface ICryptoService
    {
        string GenerateUserPasswordHash(string rawPassword);
    }
}
