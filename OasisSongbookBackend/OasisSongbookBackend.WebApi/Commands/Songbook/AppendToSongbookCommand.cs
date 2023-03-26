namespace OasisSongbookBackend.WebApi.Commands.Songbook
{
    public class AppendToSongbookCommand
    {
        public string SongbookId { get; set; }
        public string SongId { get; set; }
        public string UserId { get; set; }
        public int Order { get; set; }
    }
}
