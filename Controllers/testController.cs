using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Databases;

namespace MusicAndSocial.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly IMongoDatabase db;

        public testController(IMongoDatabase db)
        {
            this.db = db;
        }

        [HttpGet]
        public async void Get()
        {
            var a = await db.FindUser("fonts1215@gmail.com");
        }
    }
}