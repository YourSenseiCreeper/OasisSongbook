using MongoDB.Bson;
using OasisSongbook.Domain.Songbook;
using OasisSongbook.Domain.Songbook.Dto;

namespace OasisSongbook.Business.Mappers
{
    public static class SongbookMapper
    {
        public static Songbook ToSongbook(this CreateSongbookDto dto)
        {
            return new Songbook
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Title = dto.Title,
                Layout = dto.Layout,
                Entries = dto.Entries.Select(e => new SongbookEntry
                {
                    _id = ObjectId.GenerateNewId().ToString(),
                    SongId = e.SongId,
                    CustomStyleOptions = e.CustomStyleOptions
                }).ToList()
            };
        }
    }
}
