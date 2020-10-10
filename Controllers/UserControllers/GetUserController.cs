using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MRequest = MusicAndSocial.Api.Model.Request.UserControllers;
using MResponse = MusicAndSocial.Api.Model.Response.UserControllers;
using MusicAndSocial.Databases;

namespace MusicAndSocial.Controllers.UserControllers
{
    [Route("api/users/me")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly IMongoDatabase db;

        public GetUserController(IMongoDatabase db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<MResponse.User> Get([FromBody] MRequest.User user)
        {
            if (!string.IsNullOrEmpty(user.Id))
            {
                var u = await db.FindUserById(Guid.Parse(user.Id));
                if (u != null)
                    return new MResponse.User(u.Name, u.Surname, u.Birth, u.Email, u.Genres);
                else return null;
            }
            else return null;
        }
    }
}