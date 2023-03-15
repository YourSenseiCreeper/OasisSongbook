namespace OasisSongbook.Business.Model.Songbook
{
    public class FullSongbookEntry
    {
        public Song.Song Song { get; set; }
        public Dictionary<string, string> CustomStyleOptions { get; set; }
    }
}
