using Microsoft.AspNetCore.Mvc;
using MusicAndSocial.Api.Model.Request;
using MusicAndSocial.Api.Model.Response;
using MusicAndSocial.Api.Services.Interfaces;
using System.Threading.Tasks;
using static MusicAndSocial.Common.Constants.Tokens;
using static MusicAndSocial.Common.Constants.Endpoints.SpotifyEndpoints;

namespace MusicAndSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyAuthenticationController : ControllerBase
    {
        private readonly ISpotifyServices spotifyServices;

        public SpotifyAuthenticationController(ISpotifyServices spotifyServices)
        {
            this.spotifyServices = spotifyServices;
        }

        [HttpGet()]
        public async Task<AuthorizationToken> Get(string code, string state)
        {
            TokenRequest tokenRequest = new TokenRequest(code, SpotifyAccessRedirectEndpoint(), ClientId, SecretId); //TODO SET STATIC PARAM
            return await spotifyServices.RequestToken(tokenRequest);
            //TODO to save token
        }
    }
}