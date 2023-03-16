using OasisSongbook.Business.Model.Songbook;

namespace OasisSongbook.Business.Services.Interfaces
{
    public interface IDocxTemplateService
    {
        SongbookGenerateResponse Generate(string userId, FullSongbook songbook);
    }
}
