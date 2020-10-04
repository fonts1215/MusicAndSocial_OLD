using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Common.Utils;
using MusicAndSocial.Databases;
using MusicAndSocial.Models;
using System;
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
                user.Id = Guid.NewGuid();
                var result = db.InsertUser(user);
                if(result == MongoDBCode.Success)
                    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK};
                if(result == MongoDBCode.DataIsPresent)
                    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.Conflict };
                else
                    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
            else
            {
                return new HttpResponseMessage{ StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }
    }
}
