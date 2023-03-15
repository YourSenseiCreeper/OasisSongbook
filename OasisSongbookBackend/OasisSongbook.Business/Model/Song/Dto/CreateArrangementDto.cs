using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Song.Dto
{
    public class CreateArrangementDto
    {
        public ArrangementType Type { get; set; }
        public List<CreateVerseArrangementDto> Verse { get; set; }
    }
}
