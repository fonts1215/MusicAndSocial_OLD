using Microsoft.AspNetCore.Mvc;
using Model = MusicAndSocial.Models;
using System.Collections.Generic;
using MusicAndSocial.Databases;
using System.Threading.Tasks;

namespace MusicAndSocial.Controllers.GenreControllers
{
    [Route("api/genres/all")]
    [ApiController]
    public class GetAllGenresController : ControllerBase
    {
        private readonly IMongoDatabase db;

        public GetAllGenresController(IMongoDatabase db)
        {
            this.db = db;
        }


        // GET: api/genres/all
        [HttpGet]
        public async Task<List<Model.Genre>> Get()
        {
            var result = await db.GetAllGenre();
            return result;
        }
    }
}