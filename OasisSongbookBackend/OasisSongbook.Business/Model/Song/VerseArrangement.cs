namespace OasisSongbook.Business.Model.Song
{
    public class VerseArrangement
    {
        public string _id { get; set; }
        public int VerseIndex { get; set; }
        // Bicie
        public List<VerseArrangementEntry> Entries { get; set; }
    }
}
