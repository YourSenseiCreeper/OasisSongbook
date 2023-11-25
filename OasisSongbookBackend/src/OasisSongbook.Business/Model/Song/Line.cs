namespace OasisSongbook.Business.Model.Song
{
    public class Line
    {
        public string _id { get; set; }
        public string Text { get; set; }
        public int? Repetitions { get; set; }
        public int? RepetitionsInVerse { get; set; }
        public List<ArrangementEntry> GuitarArrangement { get; set; }
    }
}
