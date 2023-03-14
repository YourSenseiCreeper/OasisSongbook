using Microsoft.AspNetCore.Mvc;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Model.Songbook;
using OasisSongbook.Business.Model.Songbook.Dto;
using OasisSongbook.Business.Services.Interfaces;

namespace OasisSongbookBackend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("{songbookId}")]
        public ActionResult Generate(int songbookId)
        {
            _docxTemplateService.Test();
            return new OkResult();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSongbookDto command)
        {
            // current user Id z requesta
            var user = _context.Users.Get(command.UserId);
            if (user == null)
                return new BadRequestObjectResult($"Not found user with id: '{command.UserId}'");

            var songbook = new Songbook
            {
                _id = new ObjectId
                Title = command.Title,
                Layout = command.Layout,
                Entries = command.Entries.Select(e => new SongbookEntry { SongId = e.SongId, CustomStyleOptions = e.CustomStyleOptions }).ToList()
            }
        }
    }
}