namespace OasisSongbook.Domain.Songbook
{
    public class FullSongbookEntry
    {
        public string Title { get; set; }
        public List<ExportVerse> Verses { get; set; }
        public Dictionary<string, string> CustomStyleOptions { get; set; }
    }
}
