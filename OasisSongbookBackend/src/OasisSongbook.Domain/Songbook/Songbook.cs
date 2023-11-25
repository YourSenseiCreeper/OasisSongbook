using OasisSongbook.Domain.Enum;

namespace OasisSongbook.Domain.Songbook
{
    public class Songbook
    {
        public string _id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public SongbookLayout Layout { get; set; }
        public List<SongbookEntry> Entries { get; set; }
        public List<string> DocxFilesUrls { get; set; }
        public string ShareUrl { get; set; }
    }
}
