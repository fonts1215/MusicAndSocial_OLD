using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Api.Model.Response;
using MusicAndSocial.Databases;
using MusicAndSocial.Models;
using System.Net.Http;

namespace MusicAndSocial.Controllers.Accounts
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMongoDatabase db;

        public RegisterController(IMongoDatabase db)
        {
            this.db = db;
        }


        // POST: api/register
        [HttpPost]
        public HttpResponseMessage Post([FromBody] User user)
        {
            if(user != null 
                && !string.IsNullOrEmpty(user.Email) 
                && !string.IsNullOrEmpty(user.Password)
                && !string.IsNullOrEmpty(user.Name)
                && !string.IsNullOrEmpty(user.Surname))
            {
                db.InsertUser(user);
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK};
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}
