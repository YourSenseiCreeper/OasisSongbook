using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OasisSongbook.Business.Services.Interfaces;
using OasisSongbook.Business.Services.Options;
using OasisSongbook.Domain.Songbook;
using SharpDocx;

namespace OasisSongbook.Business.Services
{
    public class DocxTemplateService : IDocxTemplateService
    {
        private readonly ILogger<DocxTemplateService> _logger;
        private readonly DocxTemplateServiceOptions _options;
        private readonly IFileService _fileService;

        public DocxTemplateService(ILogger<DocxTemplateService> logger,
            IOptions<DocxTemplateServiceOptions> options,
            IFileService fileService)
        {
            _logger = logger;
            _options = options.Value;
            _fileService = fileService;
        }

        public SongbookGenerateResponse Generate(string userId, FullSongbook fullSongbook)
        {
            var outputPath = $"{_options.OutputPath}/{userId}";
            _fileService.CreateFolderIfNotExist(outputPath);

            var sterilizedSongbookName = _fileService.SterilizeFileName(fullSongbook.Title);
            var fileName = sterilizedSongbookName + ".docx";

            try
            {
                var document = DocumentFactory.Create(_options.OneColumnTemplatePath, fullSongbook);
                document.Generate($"{outputPath}/{fileName}", fullSongbook);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), outputPath, fileName);
                return new SongbookGenerateResponse { Filename = fileName, Data = File.ReadAllBytes(filePath) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Thrown exception");
            }

            return null;
        }
    }
}
