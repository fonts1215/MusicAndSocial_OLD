using System;

namespace MusicAndSocial.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public Artist FavoriteArtist { get; set; } TODO ARTIST
        //public List<Genre> Genres { get; set; }
    }
}
