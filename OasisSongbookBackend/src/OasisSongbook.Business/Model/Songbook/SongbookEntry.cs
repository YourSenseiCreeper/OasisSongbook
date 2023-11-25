namespace OasisSongbook.Business.Model.Songbook
{
    public class SongbookEntry
    {
        public string _id { get; set; }
        public string SongId { get; set; }
        public int Order { get; set; }
        public Dictionary<string, string> CustomStyleOptions { get; set; }
    }
}
