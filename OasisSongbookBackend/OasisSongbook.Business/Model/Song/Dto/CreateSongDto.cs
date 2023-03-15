namespace OasisSongbook.Business.Model.Song.Dto
{
    public class CreateSongDto
    {
        public string Title { get; set; }
        public int SuggestedBmp { get; set; }
        public List<CreateVerseDto> Verses { get; set; }
        public List<CreateArrangementDto> Arrangements { get; set; }
    }
}
