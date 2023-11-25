namespace OasisSongbook.Domain.Song.Dto
{
    public class CreateVerseArrangementDto
    {
        public int VerseIndex { get; set; }
        public List<ArrangementEntry> Entries { get; set; }
    }
}
