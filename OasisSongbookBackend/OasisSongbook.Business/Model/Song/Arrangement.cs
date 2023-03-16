using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Song
{
    public class Arrangement
    {
        public string _id { get; set; }
        public ArrangementType Type { get; set; }
        // Bicie - jako dodatkowa opcja w dictionary
        public List<VerseArrangement> Verse { get; set; }
    }
}
