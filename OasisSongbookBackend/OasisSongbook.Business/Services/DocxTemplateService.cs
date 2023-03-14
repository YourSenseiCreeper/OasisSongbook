using OasisSongbook.Business.Model;
using OasisSongbook.Business.Services.Interfaces;
using SharpDocx;

namespace OasisSongbook.Business.Services
{
    public class DocxTemplateService : IDocxTemplateService
    {
        public void Test()
        {
            var songbookModel = new SongbookTemplateModel { Name = "asfd" };
            var document = DocumentFactory.Create("templates/two-column-template.docx", songbookModel);
            document.Generate("output/output.docx", songbookModel);
        }
    }
}
