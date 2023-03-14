namespace OasisSongbook.Business.Model.Song
{
    public class ModificationHistoryEntry
    {
        public string _id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedOn { get; set; }
        // zmiany?
    }
}
