namespace OasisSongbook.Business.Model.Song
{
    public class Song
    {
        public string _id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public List<ModificationHistoryEntry> ModificationHistory { get; set; }
        public int SuggestedBmp { get; set; }
        public List<Verse> Verses { get; set; }
        public List<Arrangement> Arrangements { get; set; }
    }
}
