using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Song
{
    public class Arrangement
    {
        public string _id { get; set; }
        public ArrangementType Type { get; set; }
        public List<VerseArrangement> Verse { get; set; }
    }
}
