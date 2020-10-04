using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Databases;
using MusicAndSocial.Common.Utils;
using Model = MusicAndSocial.Models;
using System.Collections.Generic;
using System.Net.Http;
using MusicAndSocial.Api.Model.Request.GenreControllers;

namespace MusicAndSocial.Controllers.Genre
{
    [Route("api/genres/add")]
    [ApiController]
    public class AddGenreController : ControllerBase
    {
        private readonly IMongoDatabase db;

        public AddGenreController(IMongoDatabase db)
        {
            this.db = db;
        }


        // POST: api/genres/add
        [HttpPost]
        public HttpResponseMessage Post([FromBody] ModifyGenresRequest request)
        {
            if (request.Genre != null && !string.IsNullOrEmpty(request.Email))
            {
                var result = db.UserUpdateGenres(request.Email, new List<Model.Genre>(request.Genre));
                if (result == MongoDBCode.Success)
                    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK };
                else
                    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
            else
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };  
        }
    }
}