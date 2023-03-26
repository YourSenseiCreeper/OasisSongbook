using Microsoft.AspNetCore.Mvc;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Model.Song;
using OasisSongbook.Business.Model.Song.Dto;
using OasisSongbook.Business.Mappers;

namespace OasisSongbookBackend.WebApi.Controllers
{
    [ApiController]
    [Route("song")]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        private readonly OasisSongbookNoSqlContext _context;
        public SongController(ILogger<SongController> logger, 
            OasisSongbookNoSqlContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSongDto command)
        {
            // current user Id z requesta
            var song = SongMappers.ToSong(command);
            await _context.Songs.Add(song);
            return new OkResult();
        }

        [HttpGet]
        public async Task<IEnumerable<Song>> GetAll()
        {
            var songs = await _context.Songs.GetAll();
            return songs;
        }

        [HttpGet("{id}")]
        public async Task<Song> Get(string songId)
        {
            var song = await _context.Songs.Get(songId);
            return song;
        }
    }
}