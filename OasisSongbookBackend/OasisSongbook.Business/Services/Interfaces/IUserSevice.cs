using OasisSongbook.Business.Model;
using OasisSongbook.Business.Model.Dto;

namespace OasisSongbook.Business.Services.Interfaces
{
    public interface IUserSevice
    {
        Task CreateUser(CreateUserDto userDto);
    }
}
