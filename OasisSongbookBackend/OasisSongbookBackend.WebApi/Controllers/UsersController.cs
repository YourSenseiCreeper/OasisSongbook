using KoszalinNoSQLLibrary.Business;
using KoszalinNoSQLLibrary.Business.Model;
using KoszalinNoSQLLibrary.Business.Model.Dto;
using KoszalinNoSQLLibrary.Business.Service;
using Microsoft.AspNetCore.Mvc;
using OasisSongbook.Business.Context;

namespace OasisSongbookBackend.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly OasisSongbookNoSqlContext _context;

        public UsersController(ILogger<UsersController> logger, OasisSongbookNoSqlContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task Create([FromBody] CreateUserDto userDto)
        {
            var user = new User
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = PasswordHashService.Generate(userDto.Password),
                IsActive = userDto.IsActive,
                Role = userDto.Role,
                RentalHistory = new List<RentalHistoryEntry>()
            };
            await _context.Users.Add(user);
        }

        [HttpGet]
        public async Task<IEnumerable<UserWithoutHistoryDto>> GetAll()
        {
            var users = await _context.UsersWithoutHistory.GetAll();
            return users;
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
            var update = Builders<User>.Update.Set(nameof(Business.Model.User.Name), user.Name)
                .Set(nameof(Business.Model.User.Email), user.Email)
                .Set(nameof(Business.Model.User.IsActive), user.IsActive)
                .Set(nameof(Business.Model.User.Role), user.Role);
            await _context.Users.Update(Builders<User>.Filter.Eq("_id", user._id), update);
        }
    }
}