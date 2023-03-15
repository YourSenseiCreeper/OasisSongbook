using MongoDB.Bson;
using OasisSongbook.Business.Model.Song;
using OasisSongbook.Business.Model.Song.Dto;

namespace OasisSongbook.Business.Mappers
{
    public static class SongMappers
    {
        public static Song ToSong(CreateSongDto songDto)
        {
            return new Song
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Title = songDto.Title,
                ModificationHistory = new List<ModificationHistoryEntry>(),
                SuggestedBmp = songDto.SuggestedBmp,
                Verses = songDto.Verses.Select(v => new Verse
                {
                    _id = ObjectId.GenerateNewId().ToString(),
                    Repetitions = v.Repetitions,
                    Lines = v.Lines.Select(l => new Line
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Text = l.Text,
                        Repetitions = l.Repetitions,
                        RepetitionsInVerse = l.RepetitionsInVerse
                    }).ToList()
                }).ToList(),
                Arrangements = songDto.Arrangements.Select(a => new Arrangement
                {
                    _id = ObjectId.GenerateNewId().ToString(),
                    Type = a.Type,
                    Verse = a.Verse.Select(v => new VerseArrangement
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        VerseIndex = v.VerseIndex,
                        Entries = v.Entries
                    }).ToList(),
                }).ToList()
            };
        }
    }
}
