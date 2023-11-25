using OasisSongbook.Domain.Enum;

namespace OasisSongbook.Domain.Song.Dto
{
    public class CreateArrangementDto
    {
        public ArrangementType Type { get; set; }
        public List<CreateVerseArrangementDto> Verse { get; set; }
    }
}
