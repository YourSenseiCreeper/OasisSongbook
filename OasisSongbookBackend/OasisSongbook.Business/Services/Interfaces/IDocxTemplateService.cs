using OasisSongbook.Business.Model.Songbook;

namespace OasisSongbook.Business.Services.Interfaces
{
    public interface IDocxTemplateService
    {
        void Generate(string userId, FullSongbook songbook);
    }
}
