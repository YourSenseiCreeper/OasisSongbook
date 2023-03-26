namespace OasisSongbookBackend.WebApi.Commands.Songbook
{
    public class ReorderCommand
    {
        public string SongbookId { get; set; }
        public string SongId { get; set; }
        public string UserId { get; set; }
        public int NewOrder { get; set; }
    }
}
