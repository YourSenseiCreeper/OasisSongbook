namespace OasisSongbook.Business.Model.Song.Dto
{
    public class CreateVerseDto
    {
        public List<CreateLineDto> Lines { get; set; }
        public int Repetitions { get; set; }
    }
}
