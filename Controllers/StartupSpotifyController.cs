using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Api.Model.Request;
using MusicAndSocial.Api.Model.Response;
using System;
using static MusicAndSocial.Common.Constants.Tokens;
using static MusicAndSocial.Common.Constants.Endpoints.SpotifyEndpoints;

namespace MusicAndSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartupSpotifyController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<AuthenticateSpotify> Get()  //USED TO RETURN LINK FOR CONVALIDATION SPOTIFY
        {
            string guidString = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            AuthorizeRequest authorizeRequest = new AuthorizeRequest(ClientId, "code", SpotifyAccessRedirectEndpoint(), guidString, Scope);
            var response = new AuthenticateSpotify()
            {
                Url = SpotifyAuthorization(authorizeRequest)
            };
            return response;
        }
    }
}