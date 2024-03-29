﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Mappers;
using OasisSongbook.Business.Services.Interfaces;
using OasisSongbook.Domain;
using OasisSongbook.Domain.Enum;
using OasisSongbook.Domain.Song;
using OasisSongbook.Domain.Songbook;
using OasisSongbook.Domain.Songbook.Dto;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<SongbookDto>> GetById(string id)
        {
            // pobranie current user id i sprawdzenie czy ma dostęp 
            var songbook = await _context.Songbooks.Get(id);
            if (songbook == null)
                return new BadRequestObjectResult($"Not found songbook with id: '{id}'");

            var songbookDto = new SongbookDto
            {
                _id = songbook._id,
                Title = songbook.Title,
                AuthorId = songbook.AuthorId,
                Layout = songbook.Layout,
                ShareUrl = songbook.ShareUrl,
                DocxFilesUrls = songbook.DocxFilesUrls,
                Entries = new List<SongbookEntryDto>()
            };

            var songsEntries = songbook.Entries.OrderBy(e => e.Order).ToList();
            var songs = await _context.Songs.Query(Builders<Song>.Filter.In(s => s._id, songsEntries.Select(e => e.SongId)));

            foreach (var songEntry in songsEntries)
            {
                var song = songs.First(s => s._id == songEntry.SongId);
                songbookDto.Entries.Add(new SongbookEntryDto
                {
                    _id = songEntry._id,
                    Order = songEntry.Order,
                    CustomStyleOptions = songEntry.CustomStyleOptions,
                    Song = song,
                });
            }
            return Ok(songbookDto);
        }

        [HttpPost("append")]
        public async Task<ActionResult> AppendToSongbook([FromBody] AppendToSongbookCommand command)
        {
            //current user
            var user = await _context.Users.Get(command.UserId);
            if (user == null)
                return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");

            var song = await _context.Songs.Get(command.SongId);
            if (song == null)
                return new BadRequestObjectResult($"Not found song with id: '{command.SongId}'");

            var songbook = await _context.Songbooks.Get(command.SongbookId);
            if (songbook == null)
                return new BadRequestObjectResult($"Not found songbook with id: '{command.SongbookId}'");

            var newEntry = new SongbookEntry
            {
                _id = ObjectId.GenerateNewId().ToString(),
                SongId = command.SongId,
            };

            var filter = Builders<Songbook>.Filter.Eq(u => u._id, command.UserId);
            var update = Builders<Songbook>.Update.AddToSet(nameof(Songbook.Entries), newEntry);
            await _context.Songbooks.Update(filter, update);

            return new OkResult();
        }

        [HttpPost("remove")]
        public async Task<ActionResult> RemoveFromSongbook([FromBody] RemoveFromSongbookCommand command)
        {
            //current user
            var user = await _context.Users.Get(command.UserId);
            if (user == null)
                return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");

            var song = await _context.Songs.Get(command.SongId);
            if (song == null)
                return new BadRequestObjectResult($"Not found song with id: '{command.SongId}'");

            var songbook = await _context.Songbooks.Get(command.SongbookId);
            if (songbook == null)
                return new BadRequestObjectResult($"Not found songbook with id: '{command.SongbookId}'");

            var entry = songbook.Entries.FirstOrDefault(e => e.SongId == command.SongId);
            if (entry == null)
                return new BadRequestObjectResult($"Not found song with id: '{command.SongId}' in songbook {command.SongbookId}");

            var filter = Builders<Songbook>.Filter.Eq(u => u._id, command.UserId);
            var update = Builders<Songbook>.Update.Pull(nameof(Songbook.Entries), entry);
            await _context.Songbooks.Update(filter, update);

            return new OkResult();
        }

        [HttpPost("reorder")]
        public async Task<ActionResult> Reorder([FromBody] ReorderCommand command)
        {
            //current user
            // sprawdzanie praw własności do śpiewnika
            var user = await _context.Users.Get(command.UserId);
            if (user == null)
                return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");

            var song = await _context.Songs.Get(command.SongId);
            if (song == null)
                return new BadRequestObjectResult($"Not found song with id: '{command.SongId}'");

            var songbook = await _context.Songbooks.Get(command.SongbookId);
            if (songbook == null)
                return new BadRequestObjectResult($"Not found songbook with id: '{command.SongbookId}'");

            var entry = songbook.Entries.FirstOrDefault(e => e.SongId == command.SongId);
            if (entry == null)
                return new BadRequestObjectResult($"Not found song with id: '{command.SongId}' in songbook {command.SongbookId}");

            var filter = Builders<Songbook>.Filter.Eq(s => s._id, command.SongbookId);
            var update = Builders<Songbook>.Update.Pull(nameof(Songbook.Entries), entry);
            await _context.Songbooks.Update(filter, update);

            // podwójny update ?

            return new OkResult();
        }

        [HttpPost("generate")]
        public async Task<FileContentResult> Generate([FromBody] GenerateSongbookCommand command)
        {
            var user = await _context.Users.Get(command.UserId);
            if (user == null)
            {
                //return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");
                return null;
            }

            var songbook = await _context.Songbooks.Get(command.SongbookId);
            if (songbook == null)
            {
                //return new BadRequestObjectResult($"Not found songbook with id: '{command.SongbookId}'");
                return null;
            }

            var songIds = songbook.Entries.Select(e => e.SongId).ToHashSet();
            var songs = await _context.Songs.GetAll();
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
            var verses = song.Verses.Select(v => new ExportVerse
            {
                Lines = v.Lines.Select(l => new ExportLine
                {
                    Text = l.Text,
                    Notes = string.Join(" ", l.GuitarArrangement.Select(a => a.Note)),
                    Repetitions = l.Repetitions ?? 0,
                }).ToList()
            }).ToList();

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
            var update = Builders<User>.Update.AddToSet(nameof(OasisSongbook.Domain.User.Songbooks), songbook);
            await _context.Users.Update(filter, update);

            return new OkResult();
        }
    }
}