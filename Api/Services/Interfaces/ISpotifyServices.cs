using MusicAndSocial.Api.Model.Request;
using MusicAndSocial.Api.Model.Response;
using System.Threading.Tasks;

namespace MusicAndSocial.Api.Services.Interfaces
{
    public interface ISpotifyServices
    {
        public Task<AuthorizationToken> RequestToken(TokenRequest tokenRequest);
        public Task<AuthorizeResponse> AuthorizationAccess(AuthorizeRequest authorizeRequest);
        public Task<AuthorizationToken> RefreshToken(AuthorizationToken authorizationToken);
    }
}
