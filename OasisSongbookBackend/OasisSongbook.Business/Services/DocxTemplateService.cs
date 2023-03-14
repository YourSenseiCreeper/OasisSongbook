using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OasisSongbook.Business.Model.Songbook;
using OasisSongbook.Business.Services.Interfaces;
using OasisSongbook.Business.Services.Options;
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

        public void Generate(string userId, Songbook songbook)
        {
            var outputPath = $"{_options.OutputPath}/{userId}";
            _fileService.CreateFolderIfNotExist(outputPath);

            var sterilizedSongbookName = _fileService.SterilizeFileName(songbook.Title);
            var outputFilePath = $"{outputPath}/{sterilizedSongbookName}.docx";

            try
            {
                var document = DocumentFactory.Create(_options.OneColumnTemplatePath, songbook);
                document.Generate(outputFilePath, songbook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Thrown exception");
            }
        }
    }
}
