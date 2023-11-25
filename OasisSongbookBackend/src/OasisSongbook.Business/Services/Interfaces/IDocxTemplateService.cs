using OasisSongbook.Domain.Songbook;

namespace OasisSongbook.Business.Services.Interfaces
{
    public interface IDocxTemplateService
    {
        SongbookGenerateResponse Generate(string userId, FullSongbook songbook);
    }
}
