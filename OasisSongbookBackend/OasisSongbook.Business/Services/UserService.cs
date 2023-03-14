using OasisSongbook.Business.Context;
using OasisSongbook.Business.Mappers;
using OasisSongbook.Business.Model.Dto;
using OasisSongbook.Business.Services.Interfaces;

namespace OasisSongbook.Business.Services
{
    public class UserService : IUserSevice
    {
        private readonly ICryptoService _cryptoService;
        private readonly OasisSongbookNoSqlContext _context;
        public UserService(ICryptoService cryptoService,
            OasisSongbookNoSqlContext context)
        {
            _cryptoService = cryptoService;
            _context = context;
        }

        public async Task CreateUser(CreateUserDto userDto)
        {
            var user = userDto.ToUser();
            user.PasswordHash = _cryptoService.GenerateUserPasswordHash(userDto.Password);
            await _context.Users.Add(user);
        }
    }
}
