using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Mappers;
using OasisSongbook.Business.Model;
using OasisSongbook.Business.Model.Enum;
using OasisSongbook.Business.Model.Song;
using OasisSongbook.Business.Model.Songbook;
using OasisSongbook.Business.Model.Songbook.Dto;
using OasisSongbook.Business.Services.Interfaces;
using OasisSongbookBackend.WebApi.Commands.Songbook;

namespace OasisSongbookBackend.WebApi.Controllers
{
    [ApiController]
    [Route("songbook")]
    public class SongbookController : ControllerBase
    {
        private readonly ILogger<SongbookController> _logger;
        private readonly OasisSongbookNoSqlContext _context;
        private readonly IDocxTemplateService _docxTemplateService;
        public SongbookController(ILogger<SongbookController> logger, 
            OasisSongbookNoSqlContext context,
            IDocxTemplateService docxTemplateService)
        {
            _logger = logger;
            _context = context;
            _docxTemplateService = docxTemplateService;
        }

        [HttpPost("generate")]
        public async Task<ActionResult> Generate([FromBody] GenerateSongbookCommand command)
        {
            var user = await _context.Users.Get(command.UserId);
            if (user == null)
                return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");

            var songbook = user.Songbooks.FirstOrDefault(s => s._id == command.SongbookId);
            if (songbook == null)
                return new BadRequestObjectResult($"Not found songbook with id: '{command.SongbookId}'");

            var songIds = songbook.Entries.Select(e => e.SongId).ToHashSet();
            var songs = await _context.Song.GetAll();
            songs = songs.Where(s => songIds.Contains(s._id)).ToList();

            var fullSongbook = new FullSongbook
            {
                _id = command.SongbookId,
                Title = songbook.Title,
                Layout = songbook.Layout,
                Entries = songs.Select(s => new FullSongbookEntry {
                    Title = s.Title,
                    Verses = GetExportVerses(s, ArrangementType.Guitar) }
                ).ToList()
            };
            var response = _docxTemplateService.Generate(command.UserId, fullSongbook);

            return File(response.Data, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", response.Filename);
        }

        private List<ExportVerse> GetExportVerses(Song song, ArrangementType arrangementType)
        {
            var verses = new List<ExportVerse>();
            for(int i = 0; i < song.Verses.Count; i++)
            {
                var lines = new List<ExportLine>();
                for(int j = 0; j < song.Verses[i].Lines.Count; j++)
                {
                    var arrangementAsInt = (int)arrangementType;
                    lines.Add(new ExportLine
                    {
                        Text = song.Verses[i].Lines[j].Text,
                        Notes = string.Join(" ", song.Arrangements[arrangementAsInt].Verse[i].Entries.Select(e => e.Note))
                    });
                }
                verses.Add(new ExportVerse
                {
                    Lines = lines
                });
            }
            return verses;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSongbookDto command)
        {
            // current user Id z requesta
            var user = await _context.Users.Get(command.UserId);
            if (user == null)
                return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");

            var songbook = command.ToSongbook();
            var filter = Builders<User>.Filter.Eq(u => u._id, command.UserId);
            var update = Builders<User>.Update.AddToSet(nameof(OasisSongbook.Business.Model.User.Songbooks), songbook);
            await _context.Users.Update(filter, update);

            return new OkResult();
        }
    }
}