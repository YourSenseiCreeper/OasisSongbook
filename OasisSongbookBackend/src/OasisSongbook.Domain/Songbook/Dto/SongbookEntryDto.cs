namespace OasisSongbook.Domain.Songbook.Dto
{
    public class SongbookEntryDto
    {
        public string _id { get; set; }
        public Song.Song Song { get; set; }
        public int Order { get; set; }
        public Dictionary<string, string> CustomStyleOptions { get; set; }
    }
}