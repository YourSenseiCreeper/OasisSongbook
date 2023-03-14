using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Songbook
{
    public class Songbook
    {
        public string _id { get; set; }
        public string Title { get; set; }
        // CreatedOn?
        // ModifiedOn?
        public SongbookLayout Layout { get; set; }
        public List<SongbookEntry> Entries { get; set; }
        public List<string> DocxFilesUrls { get; set; }
        // autor?
        // share link?
    }
}
