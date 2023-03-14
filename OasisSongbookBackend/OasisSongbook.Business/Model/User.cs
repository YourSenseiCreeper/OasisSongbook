using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model
{
    public class User
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
        public List<Songbook.Songbook> Songbooks { get; set; }
    }
}
