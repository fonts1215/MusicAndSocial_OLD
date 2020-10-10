using MusicAndSocial.Models;
using System;
using System.Collections.Generic;

namespace MusicAndSocial.Api.Model.Response.UserControllers
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public List<Genre> Genres { get; set; }

        public User(string name, string surname, DateTime birth, string email, List<Genre> genres)
        {
            Name = name;
            Surname = surname;
            Birth = birth;
            Email = email;
            Genres = genres;
        }
    }
}
