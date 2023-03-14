using OasisSongbook.Business.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace OasisSongbook.Business.Services
{
    public class CryptoService : ICryptoService
    {
        public string GenerateUserPasswordHash(string rawPassword)
        {
            var passwordHash = SHA256.HashData(Encoding.UTF8.GetBytes(rawPassword));
            return Convert.ToBase64String(passwordHash);
        }
    }
}
