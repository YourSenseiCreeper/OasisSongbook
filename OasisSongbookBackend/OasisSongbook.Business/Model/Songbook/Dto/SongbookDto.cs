using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Songbook.Dto
{
    public class SongbookDto
    {
        public string _id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public SongbookLayout Layout { get; set; }
        public List<SongbookEntryDto> Entries { get; set; }
        public List<string> DocxFilesUrls { get; set; }
        public string ShareUrl { get; set; }
    }
}
