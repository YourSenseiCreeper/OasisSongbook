using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Songbook
{
    public class FullSongbook
    {
        public string _id { get; set; }
        public string Title { get; set; }
        public SongbookLayout Layout { get; set; }
        public List<FullSongbookEntry> Entries { get; set; }
    }
}
