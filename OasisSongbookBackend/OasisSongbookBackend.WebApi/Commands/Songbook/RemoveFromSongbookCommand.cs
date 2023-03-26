namespace OasisSongbookBackend.WebApi.Commands.Songbook
{
    public class RemoveFromSongbookCommand
    {
        public string SongbookId { get; set; }
        public string SongId { get; set; }
        public string UserId { get; set; }
    }
}
