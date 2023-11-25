namespace OasisSongbook.Domain.Song.Dto
{
    public class CreateSongDto
    {
        public string Title { get; set; }
        public int SuggestedBmp { get; set; }
        public List<CreateVerseDto> Verses { get; set; }
    }
}
