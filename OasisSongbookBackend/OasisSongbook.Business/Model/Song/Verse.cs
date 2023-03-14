namespace OasisSongbook.Business.Model.Song
{
    public class Verse
    {
        public string _id { get; set; }
        public List<Line> Lines { get; set; }
        public int Repetitions { get; set; }
    }
}
