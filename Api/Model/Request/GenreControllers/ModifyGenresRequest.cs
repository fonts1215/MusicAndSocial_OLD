using System.Collections.Generic;
using M = MusicAndSocial.Models;

namespace MusicAndSocial.Api.Model.Request.GenreControllers
{
    public class ModifyGenresRequest
    {
        public List<M.Genre> Genre { get; set; }
        public string Email { get; set; }
    }
}
