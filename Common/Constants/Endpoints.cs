using MusicAndSocial.Api.Model.Request;

namespace MusicAndSocial.Common.Constants
{
    public static class Endpoints
    {
        public static class SpotifyEndpoints
        {
            public static string root = "https://accounts.spotify.com";
            //AUTHENTICATION FLOW
            public static string SpotifyAuthorization(AuthorizeRequest authorizeRequest)
            {
                string scopes = "";
                authorizeRequest.Scope.ForEach(s => scopes += s + "%20");
                return $"{root}/authorize?client_id={authorizeRequest.Client_Id}&response_type=code&redirect_uri={authorizeRequest.Redirect_IUri}&scope={scopes}&state={authorizeRequest.State}";
            }
                
            public static string SpotifyAccessToken() => $"{root}/api/token";
            //public static string SpotifyAccessRedirectEndpoint() => "https%3A%2F%2Flocalhost%3A44319%2Fapi%2FSpotifyAuthentication";
            public static string SpotifyAccessRedirectEndpoint() => "https://localhost:44319/api/SpotifyAuthentication";
        }
    }
}
