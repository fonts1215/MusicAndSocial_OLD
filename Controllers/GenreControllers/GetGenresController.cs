using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Databases;
using Model = MusicAndSocial.Models;

namespace MusicAndSocial.Controllers.GenreControllers
{
    [Route("api/genres")]
    [ApiController]
    public class GetGenresController : ControllerBase
    {
        private readonly IMongoDatabase db;

        public GetGenresController(IMongoDatabase db)
        {
            this.db = db;
        }

        //GET api/genres
        [HttpGet]
        public async Task<List<Model.Genre>> Get(Guid user)
        {
            var result = await db.GetGenre(user);
            return result;
        }
    }
}