namespace OasisSongbook.Business.Model.Song
{
    public class VerseArrangement
    {
        public string _id { get; set; }
        public int VerseIndex { get; set; } // pomyśleć nad inną formą identyfikacji, może przez _id
        public List<VerseArrangementEntry> Entries { get; set; }
    }
}
