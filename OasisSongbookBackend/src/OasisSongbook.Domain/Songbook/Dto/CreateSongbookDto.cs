using OasisSongbook.Domain.Enum;

namespace OasisSongbook.Domain.Songbook.Dto
{
    public class CreateSongbookDto
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public SongbookLayout Layout { get; set; }
        public List<CreateSongbookEntryDto> Entries { get; set; }
    }
}
