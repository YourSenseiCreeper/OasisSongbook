using Microsoft.AspNetCore.Mvc;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Services.Interfaces;
using OasisSongbook.Domain;
using OasisSongbook.Domain.Dto;

namespace OasisSongbookBackend.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly OasisSongbookNoSqlContext _context;
        private readonly IUserSevice _userSevice;

        public UsersController(ILogger<UsersController> logger,
            OasisSongbookNoSqlContext context,
            IUserSevice userService)
        {
            _logger = logger;
            _context = context;
            _userSevice = userService;
        }

        [HttpPost]
        public async Task Create([FromBody] CreateUserDto userDto)
        {
            await _userSevice.CreateUser(userDto);
        }

        [HttpGet("all")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<User?> GetUser(string id)
        {
            var user = await _context.Users.Get(id);
            return user;
        }

        [HttpPatch]
        public async Task UpdateUser([FromBody] User user)
        {
            throw new NotImplementedException();
        }
    }
}