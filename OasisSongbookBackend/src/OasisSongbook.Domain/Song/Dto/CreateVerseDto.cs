namespace OasisSongbook.Domain.Song.Dto
{
    public class CreateVerseDto
    {
        public List<CreateLineDto> Lines { get; set; }
        public int Repetitions { get; set; }
    }
}
