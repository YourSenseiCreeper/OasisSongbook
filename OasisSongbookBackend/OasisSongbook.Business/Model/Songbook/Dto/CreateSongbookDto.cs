using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Songbook.Dto
{
    public class CreateSongbookDto
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public SongbookLayout Layout { get; set; }
        public List<SongbookEntryDto> Entries { get; set; }
    }
}
