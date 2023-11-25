namespace OasisSongbook.Domain.Songbook.Dto
{
    public class CreateSongbookEntryDto
    {
        public string SongId { get; set; }
        public Dictionary<string, string> CustomStyleOptions { get; set; }
    }
}
